using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WebApiEntity.Models;

namespace WebApiCQRS.Commands.NewsCommands
{
    public class AddListNews : IRequest<bool>
    {
        public IEnumerable<News> NewsList { get; set; }

        public AddListNews(IEnumerable<News> newsList)
        {
            NewsList = newsList;
        }
    }
}

