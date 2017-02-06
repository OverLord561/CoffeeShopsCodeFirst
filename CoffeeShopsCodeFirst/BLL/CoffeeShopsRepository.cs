using CoffeeShopsCodeFirst.Models;
using Microsoft.AspNet.Identity;
using MvcApplicationInternet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace CoffeeShopsCodeFirst.BLL
{
    public class CoffeeShopsRepository : IDisposable
    {
        #region System
        public ApplicationDbContext db;
        private bool _disposed;
        public CoffeeShopsRepository(ApplicationDbContext context = null)
        {
            if (context == null)
            {
                this.db = new ApplicationDbContext();
            }
            else this.db = context;
          
            _disposed = false;
           
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (db != null)
                        db.Dispose();
                }
                db = null;
                _disposed = true;

            }
        }

        #endregion
        #region User

        public ApplicationUser GetUserById(string UserID)
        {
            var res = db.Users.FirstOrDefault(x => x.Id == UserID);
            return res;
        }


        //  public
        //public string RegisterUser(Users user)
        //{
        //    string res = "";

        //    user = CheckIfUserExist(user.FirstName);
        //    if (user != null)
        //    {
        //        res = "Current user exists! Change name, please!";
        //    }
        //    else
        //    {
        //        db.Users.Add(user);
        //        db.SaveChanges();

        //        res = "Welcome, " + user.FirstName;

        //    }
        //    return res;

        //}

        //public string LogIn(string userName, string userPassword)
        //{

        //    string res = "";
        //    Users user = CheckIfUserExist(userName);
        //    if (user != null)
        //    {
        //        if (user.Password == userPassword)
        //        {
        //            res = "Hello, " + user.FirstName;
        //        }
        //        else
        //        {
        //            res = "Password is incorrect!";
        //        }
        //    }
        //    else
        //    {
        //        res = "Current user does not exist!";
        //    }
        //    return res;
        //}

        //public Users CheckIfUserExist(string name)
        //{
        //    Users user = db.Users.FirstOrDefault(x => x.FirstName.ToUpper() == name.ToUpper());

        //    return user;
        //}

        public string SaveUserPhoto(ApplicationUser user)
        {
            
            try
            {
               
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                return "";
            }

            return user.Id;
        }
        #endregion
        #region UserComment
        public List<UserComment> GetUserCommentsViaProcedure(string userID, int coffeeId)
        {

            List<UserComment> comments = db.Database.SqlQuery<UserComment>(
                "GetUserCommentsByUserIdAndCoffeeId @userID, @coffeeID",
                 new SqlParameter("coffeeID", coffeeId),
                 new SqlParameter("userID", userID)                 
                  ).ToList();
        

            return comments;
        }
        public int SaveUserComment(UserComment comment)
        {
            if (comment.UserCommentID == 0)
            {
                db.UserComments.Add(comment);
                db.SaveChanges();
            }
            else
            {

                try
                {
                    db.Entry(comment).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch 
                {
                    return 0;
                }
                //try
                //{
                //    db.Entry(comment).State = EntityState.Modified;
                //    db.SaveChanges();
                //}
                //catch (OptimisticConcurrencyException ex)
                //{
                //    RDL.Debug.LogError(ex);
                //}
            }
            return comment.UserCommentID;
        }
        public bool DeleteUserComment(int id)
        {
            bool res = false;
            var comment = db.UserComments.FirstOrDefault(x => x.UserCommentID == id);
            if (comment != null)
            {
                db.Entry(comment).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            res = true;
            return res;
        }
        public IQueryable<UserComment> GetUserCommentsByUserId(string userID)
        {
            var res = db.UserComments.Where(x =>x.UserID == userID);
            return res;
        }
        public IQueryable<UserComment> GetUserCommentsByCoffeeId(int coffeeID)
        {
            var res = db.UserComments.Where(x => x.CoffeeShopID == coffeeID);
            return res;
        }
        #endregion

        #region CoffeeShop
        public IQueryable<CoffeeShop> GetCoffeeShops()
        {
            var res = db.CoffeeShops;
            return res;
        }
        public CoffeeShop GetCoffeeShopById(int coffeeID)
        {
            var res = db.CoffeeShops.FirstOrDefault(x => x.CoffeeShopID == coffeeID);
            return res;
        }
        public int SaveCoffeeShop(CoffeeShop shop)
        {
            if (shop.CoffeeShopID == 0)
            {
                db.CoffeeShops.Add(shop);
                db.SaveChanges();
            }
            else
            {
                try
                {
                    db.Entry(shop).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch 
                {
                    return 0;
                }
            }
            return shop.CoffeeShopID;
        }
        public bool DeleteCoffeeShop(int id)
        {
            bool res = false;
            var shop = db.CoffeeShops.FirstOrDefault(x => x.CoffeeShopID == id);
            if (shop != null)
            {
                db.Entry(shop).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            res = true;
            return res;
        }
        #endregion

        #region Novelty
        public IQueryable<Novelty> GetNoveltiesByCoffeeShopID(int coffeeID)
        {
            var res = db.Novelties.Where(x => x.CoffeeShopID == coffeeID);
            return res;
        }
        public int SaveNovelty(Novelty novelty)
        {
            if (novelty.NoveltyID == 0)
            {
                db.Novelties.Add(novelty);
                db.SaveChanges();
            }
            else
            {
                try
                {
                    db.Entry(novelty).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    return 0;
                }
            }
            return novelty.NoveltyID;
        }
        public bool DeleteNovelty(int id)
        {
            bool res = false;
            var novelty = db.Novelties.FirstOrDefault(x => x.NoveltyID == id);
            if (novelty != null)
            {
                db.Entry(novelty).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            res = true;
            return res;
        }
        #endregion

    }

}