﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class User
    {
        private int v1;
        private string v2;
        private object value;

        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string FavoriteMovie { get; set; }
        public string FavoriteBook { get; set; }

        public IEnumerable<Message> IncomingMessages { get; }
        public IEnumerable<Message> OutgoingMessages { get; }

        public IEnumerable<Friend> Friends { get; set; } //my addition

        public User(
            int id,
            string firstName,
            string lastName,
            string password,
            string email,
            string photo,
            string favoriteMovie,
            string favoriteBook,
            IEnumerable<Message> incomingMessages,
            IEnumerable<Message> outgoingMessages,
            IEnumerable<Friend> myfriends
            )
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Email = email;
            this.Photo = photo;
            this.FavoriteMovie = favoriteMovie;
            this.FavoriteBook = favoriteBook;
            this.IncomingMessages = incomingMessages;
            this.OutgoingMessages = outgoingMessages;
            this.Friends = myfriends;
        }

       
    }
}
