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
    public class CommentControllerTest
    {
        // private readonly CommentController _commentController;
        // private readonly CommentsFake _comentsFake;
        // private readonly IMediator _mediator;
        //  private readonly IMapper _mapper;
        // private readonly UserManager<IdentityUser> _userManager;


        public CommentControllerTest(/*IMediator mediator, UserManager<IdentityUser> userManager, IMapper mapper,*/)
        {
            //_comentsFake = new CommentsFake();
            //_commentController = new CommentController();
            // _mediator = mediator;
            //_userManager = userManager;
            //_mapper = mapper;
        }

        [Fact]
        public async void GetCommentsById_Guid_OkCommentResult()
        {
            //Arrange
            var testGuid = new Guid("97ffda2c-0ed3-4bc7-aa21-fdc7f6726c73");
            var mediter = new Mock<IMediator>();
            var controller = new CommentController(mediter.Object);


            //Act
            var result = await controller.GetCommentsById(testGuid);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetCommentsById_Guid_NotFoundResult()
        {
            //Arrange
            var testGuid = Guid.NewGuid();
            var mediter = new Mock<IMediator>();
            var controller = new CommentController(mediter.Object);
            //Act
            var result = await controller.GetCommentsById(testGuid);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetCommentsById_Guid_RightComment()
        {
            //Arrange
            var testGuid = new Guid("97ffda2c-0ed3-4bc7-aa21-fdc7f6726c73");
            var mediter = new Mock<IMediator>();
            var controller = new CommentController(mediter.Object);

            //Act
            var result = await controller.GetCommentsById(testGuid) as OkObjectResult;

            //Assert
            Assert.IsType<OkObjectResult>(result.Value);
            Assert.Equal(testGuid, (result.Value as Comments).Id);
        }

    }
}
