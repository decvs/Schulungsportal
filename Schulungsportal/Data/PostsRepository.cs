using Schulungsportal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schulungsportal.Data
{
    public class PostsRepository
    {
        private readonly TpContext _database;

        public PostsRepository()
        {
            _database = new TpContext();
        }


        public IQueryable<Post> Query
        {
            get
            {
                return this._database.Posts.AsQueryable();
            }
        }


        internal void Insert(Post post)
        {
            var result = this._database.Posts.Add(post);
            this._database.SaveChanges();
        }

        internal Post GetById(int id)
        {
            var post = this._database.Posts.Find(id);
            return post;
        }

        internal void Delete(int id)
        {
            var post = GetById(id);
            if (post != null)
            {
                this._database.Posts.Remove(post);
                this._database.SaveChanges();
            }
        }

        internal void Update(Post model)
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