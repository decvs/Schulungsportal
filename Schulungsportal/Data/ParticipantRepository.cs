using Schulungsportal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schulungsportal.Data
{
    public class ParticipantRepository
    {
        private readonly TpContext _database;

        public ParticipantRepository()
        {
            _database = new TpContext();
        }


        public IQueryable<Participant> Query
        {
            get
            {
                return this._database.Participants.AsQueryable();
            }
        }

        public IQueryable<Participant> OldQuery 
        {
                get {
                    return new List<Participant>()
                {
                    new Participant{ Id = 1, Firstname="Christian", Lastname="von Seydlitz", Email="cvs@von-seydlitz.de", Website="www.von-seydlitz.de", Company= "private"},
                    new Participant{ Id = 2, Firstname="Irina", Lastname="von Seydlitz", Email="irina@von-seydlitz.de", Website="www.von-seydlitz.de", Company= "private"},
                    new Participant{ Id = 3, Firstname="Simon", Lastname="von Seydlitz", Email="simon@von-seydlitz.de", Website="www.von-seydlitz.de", Company= "private"},
                    new Participant{ Id = 4, Firstname="Luca", Lastname="von Seydlitz", Email="luca@von-seydlitz.de", Website="www.von-seydlitz.de", Company= "private"}
                }.AsQueryable<Participant>();
            }
        }

        internal void Insert(Participant participant)
        {
            var result = this._database.Participants.Add(participant);
            this._database.SaveChanges();
        }

        internal Participant GetById(int id)
        {
            var part = this._database.Participants.Find(id);
            return part;
        }

        internal void Delete(int id)
        {
            var part = GetById(id);
            if (part != null)
            {
                this._database.Participants.Remove(part);
                this._database.SaveChanges();
            }
        }

        internal void Update(Participant model)
        {
            //if (_database.Entry(model).State == EntityState.Detached)
            //{
            //    _database.Participants.Attach(model);
            //    _database.Entry(model).State = EntityState.Modified;
            //}

            _database.Entry(model).State = EntityState.Modified;

            _database.SaveChanges();
        }
    }
}