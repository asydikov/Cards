
export class ComponentState {
    View: boolean = true;
    Edit: boolean = false;
    Create: boolean = false;

    private reset = () => {
        this.View = false;
        this.Edit = false;
        this.Create = false;
    }

    enableViewMode = () => {
        this.reset();
        this.View = true;
    }

    enableEditMode = () => {
        this.reset();
        this.Edit = true;
    }

    enableCreateMode = () => {
        this.reset();
        this.Create = true;
    }
}
