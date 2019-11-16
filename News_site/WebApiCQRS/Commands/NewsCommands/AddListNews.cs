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
        public List<News> NewsList { get; set; }
    }
}

