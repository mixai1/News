using System;
using WebApiNews_site.Controllers;
using Xunit;
using WebApiEntity.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moq;
using WebApiCQRS.Querys.CommentsQuerys;
using WebApiEntity;

namespace XUnitTestWebApiNews_site
{
    public class GetCommentsByIdHandlerTest
    {
      
        public GetCommentsByIdHandlerTest()
        {
			
        }

        //[Fact]
        //public async void GetCommentsByIdTest_Guid_Comment()
        //{
        //    //Arrange
        //    var testGuid = new Guid("97ffda2c-0ed3-4bc7-aa21-fdc7f6726c73");
        //    // var mediter = new Mock<IMediator>();
        //    var db = new WebApiDbContext();
        //    var controller = new GetCommentsByIdHandlerTest();


        //    //Act

        //    //Assert
        //    Assert.IsType<OkObjectResult>(result);
        //}

        //[Fact]
        //public async void GetCommentsById_Guid_NotFoundResult()
        //{
        //    //Arrange
        //    var testGuid = Guid.NewGuid();
        //    var mediter = new Mock<IMediator>();
        //    //var controller = new CommentController(mediter.Object);
        //    //Act
        //    var result = await controller.GetCommentsById(testGuid);

        //    //Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}

        //[Fact]
        //public async void GetCommentsById_Guid_RightComment()
        //{
        //    //Arrange
        //    var testGuid = new Guid("97ffda2c-0ed3-4bc7-aa21-fdc7f6726c73");
        //    var mediter = new Mock<IMediator>();
        //    //var controller = new CommentController(mediter.Object);

        //    //Act
        //    var result = await controller.GetCommentsById(testGuid) as OkObjectResult;

        //    //Assert
        //    Assert.IsType<OkObjectResult>(result.Value);
        //    Assert.Equal(testGuid, (result.Value as Comments).Id);
        //}

    }
}
