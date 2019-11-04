using System;
using System.Collections.Generic;

namespace Cards.Core.Models.OkResponses
{
    public class OkResponse<TModel> where TModel : ModelBase
    {
        public string Message { get; set; }

        public Guid EntityId { get; set; }

        public TModel Entity { get; set; }

        public IEnumerable<TModel> Entities { get; set; }

        public OkResponse()
        {

        }

        public OkResponse(string message)
        {
            Message = message;
        }

        public OkResponse(Guid entityId)
        {
            EntityId = entityId;
        }


        public OkResponse(TModel entity)
        {
            Entity = entity;
        }

        public OkResponse(IEnumerable<TModel> entities)
        {
            Entities = entities;
        }
    }
}