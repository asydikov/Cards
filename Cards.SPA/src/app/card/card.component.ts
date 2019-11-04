import { Component, OnInit, HostListener } from '@angular/core';
import { Card } from '../_models/card';
import { ComponentState } from '../_models/component-state';
import { CardService } from '../_services/card.service';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { EntityEnum } from '../_models/enums/entity-enum';
import { CardSateEnum } from '../_models/enums/card-state';
import { DictionarySettings } from '../_models/dictionary-settings';
import { User } from '../_models/user';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
})
export class CardComponent implements OnInit {

  cards: Card[];
  cardForm: FormGroup;
  cardIndex: number;
  componentState: ComponentState;
  dictionarySettings: DictionarySettings;
  submitted = false;

  constructor(private fb: FormBuilder, private cardService: CardService, private authService: AuthenticationService) {
    this.cardFormBuild();
    this.componentState = new ComponentState();
    this.dictionarySettings = new DictionarySettings();
  }

  ngOnInit(): void {
    this.getDependencies();
  }

  /**
   * Creates reactive form to display a card
   */
  cardFormBuild(): void {
    this.cardForm = this.fb.group({
      card: this.fb.group({
        id: new FormControl(EntityEnum.EmptyId),
        userId: new FormControl(EntityEnum.EmptyId),
        word: new FormControl('', Validators.required),
        meaning: new FormControl('', Validators.required),
        note: new FormControl(''),
        isSaved: new FormControl(false),
        modeId: new FormControl('', Validators.required),
        categoryId: new FormControl('', Validators.required),
        repeatRateId: new FormControl('', Validators.required),
        createdAt: new FormControl(new Date().toUTCString()),
        updatedAt: new FormControl(new Date().toUTCString()),
      }),
      settings: this.fb.group({
        isPrev: new FormControl(false),
        isNext: new FormControl(false)
      })

    });
  }

  /**
   * Fills card form with card entity
   * @param entity card
   */
  cardFill(entity: Card): void {
    entity = entity || new Card();
    this.cardForm.get('card').setValue({
      id: entity.id,
      userId: entity.userId,
      word: entity.word,
      meaning: entity.meaning,
      note: entity.note,
      modeId: entity.modeId,
      isSaved: entity.isSaved,
      categoryId: entity.categoryId,
      repeatRateId: entity.repeatRateId,
      createdAt: entity.createdAt,
      updatedAt: entity.updatedAt,
    });
  }

  /**
   * Convenience getter for easy access to form fields
   */
  get cardF() { return this.cardForm.get('card'); }

  /**
   * Convenience getter for easy access to form fields
   */
  get settingsF() { return this.cardForm.get('settings').value; }

  /**
   * Provides additional operations related to card options
   * @param cardIndex card index in cards array
   */
  setCardToCardForm(cardIndex: number): void {
    if (cardIndex === -1 || cardIndex === this.cards.length)
      return;

    let selectedCard = this.cards[cardIndex];
    this.cardFill(selectedCard);
    this.changeSelectedDictionary(selectedCard.categoryId, selectedCard.modeId, selectedCard.repeatRateId);
    this.checkCardsArrayEdges();
  }

  /**
   * Event handler for displaying next card
   */
  nextCard(): void {
    this.setCardToCardForm(++this.cardIndex);
  }

  /**
   * Event handler for displaying previous card
   */
  prevCard(): void {
    this.setCardToCardForm(--this.cardIndex);
  }

  /**
   * Determines whether next and prev buttons on card form disabled or not
   */
  checkCardsArrayEdges(): void {
    let settings = this.cardForm.get('settings');

    if (this.cards.length > 0 && this.cardIndex + 1 < this.cards.length) {
      settings.patchValue({ isNext: true });
    } else {
      settings.patchValue({ isNext: false });
    }

    if (this.cards.length > 0 && this.cardIndex - 1 >= 0) {
      settings.patchValue({ isPrev: true });
    } else {
      settings.patchValue({ isPrev: false });
    }
  }

  /**
   * Changes card form state to createMode
   */
  createMode(): void {
    this.changeCardSate(CardSateEnum.Create)
    this.cardFill(new Card());
  }

  /**
   * Changes card form state to editMode
   */
  editMode(): void {
    this.changeCardSate(CardSateEnum.Edit);
    let cardCopy = Object.assign({}, this.cardForm.get('card').value);
    this.cardFill(cardCopy);

  }

  /**
   * Cancels all changes related to displaying card by resetting the form
   */
  cancel(): void {
    if (this.cards.length === 0) {
      this.cardForm.get('card').reset();
    } else {
      this.setCardToCardForm(this.cardIndex);
    }
    this.changeCardSate(CardSateEnum.View);
  }

  /**
   * Performs additional logic during the changng card form state
   * @param state card state enumeration 
   */
  changeCardSate(state: CardSateEnum): void {
    let card = this.cardForm.get('card').value as Card;
    switch (state) {
      case CardSateEnum.View:
        this.componentState.enableViewMode();
        this.changeSelectedDictionary(card.categoryId, card.modeId, card.repeatRateId);
        break;
      case CardSateEnum.Edit:
        this.componentState.enableEditMode();
        this.changeSelectedDictionary(card.categoryId, card.modeId, card.repeatRateId);
        break;
      case CardSateEnum.Create:
        this.componentState.enableCreateMode();
        this.changeSelectedDictionary(EntityEnum.EmptyId, EntityEnum.EmptyId, EntityEnum.EmptyId);
        break;
    }

    this.dictionarySettings.setAllDisableValue(this.componentState.View);
  }

  /**
   * Detects the dictionary changes in dropdown controls
   * @param categoryId from category dictionary
   * @param modeId from mode dictionary
   * @param repeatRateId from repeatreate dictionary
   */
  changeSelectedDictionary(categoryId: string, modeId: string, repeatRateId: string): void {
    this.dictionarySettings.setCategoryItem(categoryId);
    this.dictionarySettings.setModeItem(modeId);
    this.dictionarySettings.setRepeatRateItem(repeatRateId);
  }

  /**
   * Performs an appropriate logic when category dictionary is changed
   * @param categoryId category id
   */
  categoryChanged(categoryId: string): void {
    this.cardForm.get('card').get('categoryId').setValue(categoryId);
    if (this.dictionarySettings.categoryId !== categoryId) {
      this.dictionarySettings.setCategoryItem(categoryId);
    }
  }

  /**
  * Performs an appropriate logic when mode dictionary is changed
  * @param modeId mode id
  */
  modeChanged(modeId: string): void {
    this.cardForm.get('card').get('modeId').setValue(modeId);
    if (this.dictionarySettings.modeId !== modeId) {
      this.dictionarySettings.setModeItem(modeId);
    }
  }

  /**
  * Performs an appropriate logic when repeatrate dictionary is changed
  * @param repeatRateId category id
  */
  repeatrateChanged(repeatRateId: string): void {
    this.cardForm.get('card').get('repeatRateId').setValue(repeatRateId);
    if (this.dictionarySettings.repeatRateId !== repeatRateId) {
      this.dictionarySettings.setRepeatRateItem(repeatRateId);
    }
  }

  /**
   * Retrieves necessary dictionaries for the card
   */
  getDependencies(): void {
    this.cardService.getDependencies().subscribe(response => {

      this.dictionarySettings.setCategoryItems(response.categories);
      this.dictionarySettings.setCategoryDisableValue(this.componentState.View);

      this.dictionarySettings.setModeItems(response.modes);
      this.dictionarySettings.setModeDisableValue(this.componentState.View);

      this.dictionarySettings.setRepeatRateItems(response.repeatRates);
      this.dictionarySettings.setRepeatRateDisableValue(this.componentState.View);

      this.getAll();
    });
  }

  /**
   * Retrieves cards from the server
   */
  getAll(): void {
    this.cardService.getAll().subscribe(response => {
      this.cards = response.entities;
      this.cardIndex = (this.cards && this.cards.length > 0) ? 0 : -1;
      this.setCardToCardForm(this.cardIndex);
    });
  }

  /**
   * Saves a card changes
   */
  save(): void {
    this.submitted = true;

    // stop here if form is invalid
    if (this.cardForm.invalid) {
      return;
    }

    let card = this.cardForm.get('card').value as Card;
    if (card.id && card.id !== EntityEnum.EmptyId) {
      this.cardService.put(card).subscribe(result => {
        // Copy edited card back to the array of cards
        Object.assign(this.cards[this.cardIndex], card);
        this.changeCardSate(CardSateEnum.View);
      });
    } else {
      this.prepareEntityToSave(card);
      this.cardService.post(card).subscribe(result => {
        // Put new entity into the arrary of cards
        card.id = result.entityId;
        this.cards.push(card);
        this.setCardToCardForm(++this.cardIndex);
        this.changeCardSate(CardSateEnum.View);
      });
    }
  }

  /**
   * Deletes a card
   */
  delete(): void {
    let card = this.cardForm.get('card').value;
    this.cardService.delete(card.id).subscribe(result => {
      this.cards.splice(this.cardIndex, 1);
      if (this.cardForm.get('settings').get('isNext').value) {
        this.setCardToCardForm(this.cardIndex);
      } else if (this.cardForm.get('settings').get('isPrev').value) {
        this.setCardToCardForm(--this.cardIndex);
      } else if (this.cards.length === 0) {
        this.cardForm.get('card').reset();
      }
    });
  }

  /**
   * Performs preparation work before saveing a new card
   * @param card card
   */
  prepareEntityToSave(card: Card): void {
    if (card.categoryId == EntityEnum.EmptyId) { card.categoryId = this.dictionarySettings.categoryId }
    if (card.modeId == EntityEnum.EmptyId) { card.modeId = this.dictionarySettings.modeId }
    if (card.repeatRateId == EntityEnum.EmptyId) { card.repeatRateId = this.dictionarySettings.repeatRateId }
    card.userId = this.authService.currentUserValue.id;
  }
}
