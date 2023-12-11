using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.TourManagerRequestDtos;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.CreateTourManagerRequest;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.DeleteTourManagerRequest;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.UpdateTourManagerRequest;
using TakeTripAsp.Application.Features.TourManagerRequestFeatures.Queries.GetAllTourManagerRequest;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.WebApp.Controllers
{
    public class TourManagerRequestController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;

        public TourManagerRequestController(IMediator mediator, UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllTourManagerRequestQueries()));
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTourManagerRequestDto dto)
        {
            var userId = _userManager.GetUserId(User);

            await _mediator.Send(new CreateTourManagerRequestCommand
            {
                ClientId = userId,
                RequestDate = DateTime.Now,
                IsApproved = false,
                IsCompanyMember = dto.IsCompanyMember,
                IsSeller = dto.IsSeller,
            });

            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Delete(string id)
        //{
        //    var request = await _mediator.Send(new GetAllTourManagerRequestQueries { ClientId = id });
        //    return View(request);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(ReadTourManagerRequestDto dto)
        //{
        //    await _mediator.Send(new DeleteTourManagerRequestCommand { ClientId = dto.ClientId });

        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var request = await _mediator.Send(new GetAllTourManagerRequestQueries { Id = id });
        //    return View(request);
        //}

        [HttpPost]
        public async Task<IActionResult> Edit(ReadTourManagerRequestDto dto)
        {
            await _mediator.Send(new UpdateTourManagerRequestCommand
            {
                ClientId = dto.ClientId,  // Змінено з Id = dto.Id на Id = dto.ClientId
                IsApproved = dto.IsApproved,
                IsCompanyMember = dto.IsCompanyMember,
                IsSeller = dto.IsSeller
            });

            return RedirectToAction("Index");
        }
    }
}










//using MediatR;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using TakeTripAsp.Application.Features.TourManagerRequestFeatures.TourManagerRequestDtos;
//using TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.CreateTourManagerRequest;
//using TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.DeleteTourManagerRequest;
//using TakeTripAsp.Application.Features.TourManagerRequestFeatures.Commands.UpdateTourManagerRequest;
//using TakeTripAsp.Application.Features.TourManagerRequestFeatures.Queries.GetAllTourManagerRequest;
//using TakeTripAsp.Domain.Entity;
//using Humanizer;

//namespace TakeTripAsp.WebApp.Controllers
//{
//    public class TourManagerRequestController : Controller
//    {
//        private readonly IMediator _mediator;
//        private readonly UserManager<AppUser> _userManager;

//        public TourManagerRequestController(IMediator mediator, UserManager<AppUser> userManager)
//        {
//            _mediator = mediator;
//            _userManager = userManager;
//        }

//        public async Task<IActionResult> Index()
//        {
//            return View(await _mediator.Send(new GetAllTourManagerRequestQueries()));
//        }

//        public IActionResult Create()
//        {
//            return View("Create");
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateTourManagerRequestDto dto)
//        {
//            var userId = _userManager.GetUserId(User);

//            await _mediator.Send(new CreateTourManagerRequestCommand
//            {
//                ClientId = userId,
//                RequestDate = DateTime.Now,
//                IsApproved = false,
//                IsCompanyMember = dto.IsCompanyMember,
//                IsSeller = dto.IsSeller,
//            });

//            return RedirectToAction("Index");
//        }

//        public async Task<IActionResult> Delete(int id)
//        {
//            var request = await _mediator.Send(new GetAllTourManagerRequestQueries 
//            {
//                Id = dto.ClientId
//            });
//            return View(request);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Delete(ReadTourManagerRequestDto dto)
//        {
//            await _mediator.Send( new DeleteTourManagerRequestCommand 
//            { 
//                ClientId = dto.ClientId
//            });

//            return RedirectToAction("Index");
//        }

//        public async Task<IActionResult> Edit(int id)
//        {
//            var request = await _mediator.Send(new GetAllTourManagerRequestQueries 
//            { 
//                ClientId = dto.ClientId
//            });
//            return View(request);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(ReadTourManagerRequestDto dto)
//        {
//            await _mediator.Send(new UpdateTourManagerRequestCommand
//            {
//                ClientId = dto.ClientId,
//                //Id = dto.Id,
//                IsApproved = dto.IsApproved,
//                IsCompanyMember = dto.IsCompanyMember,
//                IsSeller = dto.IsSeller
//            });

//            return RedirectToAction("Index");
//        }
//    }
//}









//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using TakeTripAsp.Domain.Entity;
//using TakeTripAsp.Repository;

//namespace TakeTripAsp.WebApp.Controllers
//{
//    public class TourManagerRequestController : Controller
//    {
//        private readonly IRepository<TourManagerRequest, int> repository;
//        private readonly UserManager<AppUser> _userManager;

//        public TourManagerRequestController(IRepository<TourManagerRequest, int> repository,
//          UserManager<AppUser> _userManager)
//        {
//            this.repository = repository;
//            this._userManager = _userManager;
//        }

//        public IActionResult Index()
//        {
//            return View(repository.GetAll());
//        }

//        public IActionResult Create()
//        {
//            return View("Create");
//        }

//        [HttpPost]
//        public IActionResult Create(TourManagerRequest model)
//        {
//            var userId = _userManager.GetUserId(User);
//            var tourManagerRequest = new TourManagerRequest
//            {
//                ClientId = userId,
//                RequestDate = DateTime.Now,
//                IsApproved = false,
//                IsCompanyMember = model.IsCompanyMember,
//                IsSeller = model.IsSeller,
//            };
//            repository.Create(tourManagerRequest);
//            return RedirectToAction("Index");
//        }

//        public IActionResult Delete(int id)
//        {
//            return View(repository.Get(id));
//        }

//        [HttpPost]
//        public IActionResult Delete(TourManagerRequest request)
//        {
//            repository.Delete(request);

//            return RedirectToAction("Index");
//        }

//        public IActionResult Edit(int id)
//        {
//            return View(repository.Get(id));
//        }

//        [HttpPost]
//        public IActionResult Edit(TourManagerRequest model)
//        {
//            var existingRequest = repository.Get(model.Id);
//            var userId = _userManager.GetUserId(User);

//            existingRequest.ClientId = userId;
//            existingRequest.IsApproved = model.IsApproved;
//            existingRequest.IsCompanyMember = model.IsCompanyMember;
//            existingRequest.IsSeller = model.IsSeller;

//            repository.Update(existingRequest);

//            return RedirectToAction("Index");
//        }
//    }
//}