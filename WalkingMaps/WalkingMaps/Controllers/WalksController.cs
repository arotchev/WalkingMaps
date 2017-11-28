using WalkingMaps.Infrastructure.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using WalkingMaps.Infrastructure.Core;
using WalkingMaps.ViewModels;
using WalkingMaps.Entities;
using System.Collections.Generic;
using AutoMapper;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace WalkingMaps.Controllers
{
    [Route("api/[controller]")]
    public class WalksController : Controller
    {
        IWalkRepository _walkRepository;      
        IWalkSightRepository _walkSightRepository;
        ILoggingRepository _loggingRepository;
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private readonly IAuthorizationService _authorizationService;


        public WalksController( IWalkRepository walkRepository,
                                IWalkSightRepository walkSightRepository,                             
                                ILoggingRepository loggingRepository,
                                IAuthorizationService authorizationService,
                                UserManager<User> userManager,
                                SignInManager<User> signInManager)
        {
            _walkRepository = walkRepository;
            _walkSightRepository = walkSightRepository;
            _loggingRepository = loggingRepository; 
            _authorizationService = authorizationService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        
        //[Authorize]
        [HttpGet("{page:int=0}/{pageSize=12}")]
        public async Task<IActionResult> Get(int? page, int? pageSize)
        {
            PaginationSet<WalkViewModel> pagedSet = new PaginationSet<WalkViewModel>();

            try
            {
                //if (_signInManager.IsSignedIn(User))
                if(true)
                {
                    int currentPage = page.Value;
                    int currentPageSize = pageSize.Value;

                    List<Walk> _walks = null;
                    int _totalWalks = new int();

                    //if (await _authorizationService.AuthorizeAsync(User, "AdminOnly"))
                    if (true)
                    {
                        _walks = _walkRepository
                        .AllIncluding(w => w.WalkSights)
                        .OrderBy(w => w.Id)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();                   

                        _totalWalks = _walkRepository.GetAll().Count();
                    }
                    else
                    {
                        _walks = _walkRepository
                        .FindBy(w => w.UserId == _userManager.GetUserId(User))
                        .OrderBy(w => w.Id)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                        _totalWalks = _walks.Count();

                    }

                    IEnumerable<WalkViewModel> _walksVM = Mapper.Map<IEnumerable<Walk>, IEnumerable<WalkViewModel>>(_walks);

                    pagedSet = new PaginationSet<WalkViewModel>()
                    {
                        Page = currentPage,
                        TotalCount = _totalWalks,
                        TotalPages = (int)Math.Ceiling((decimal)_totalWalks / currentPageSize),
                        Items = _walksVM
                    };
                }
                else
                {
                    CodeResultStatus _codeResult = new CodeResultStatus(401);
                    return new ObjectResult(_codeResult);
                }
            }
            catch (Exception ex)
            {
                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
                _loggingRepository.Commit();
            }

            return new ObjectResult(pagedSet);
        }


        //[Authorize]
        [HttpGet("{id:int}/sights/{page:int=0}/{pageSize=12}")]
        public PaginationSet<WalkSightViewModel> Get(int id, int? page, int? pageSize)
        {
            PaginationSet<WalkSightViewModel> pagedSet = null;

            try
            {
                int currentPage = page.Value;
                int currentPageSize = pageSize.Value;

          
                List<WalkSight> _walksights = null;
                int _totalSights = new int();

                Walk _walk = _walkRepository.GetSingle(id);

                _walksights = _walkSightRepository.AllIncluding(ws => ws.Sight, ws => ws.Walk)
                            .Where(ws => ws.WalkId == id)
                            .OrderBy(ws => ws.Id)
                            .Skip(currentPage * currentPageSize)
                            .Take(currentPageSize)
                            .ToList();

                _totalSights = _walk.WalkSights.Count();

          
                IEnumerable<WalkSightViewModel> _sightsVM = Mapper.Map<IEnumerable<WalkSight>, IEnumerable<WalkSightViewModel>>(_walksights);


                pagedSet = new PaginationSet<WalkSightViewModel>()
                {
                    Page = currentPage,
                    TotalCount = _totalSights,
                    TotalPages = (int)Math.Ceiling((decimal)_totalSights / currentPageSize),
                    Items = _sightsVM
                };
            }
            catch (Exception ex)
            {
                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
                _loggingRepository.Commit();
            }

            return pagedSet;
        }

    }
}