using MongoDB.Bson;
using System;

namespace SkillTracker.Entity
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
