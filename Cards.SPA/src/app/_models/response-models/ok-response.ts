export class OkResponse<TModel> {
    message: string;

    entityId: string;

    entity: TModel;

    entities: TModel[];
}