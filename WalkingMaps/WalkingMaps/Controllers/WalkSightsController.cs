using Microsoft.AspNetCore.Mvc;
using System;
using WalkingMaps.Entities;
using WalkingMaps.Infrastructure.Core;
using WalkingMaps.Infrastructure.Repositories.Abstract;

namespace WalkingMaps.Controllers
{
    [Route("api/[controller]")]
    public class WalkSightsController : Controller
    {
        IWalkSightRepository _walkSightRepository;
        ILoggingRepository _loggingRepository;

        public WalkSightsController(IWalkSightRepository walkSightRepository, ILoggingRepository loggingRepository)
        {
            _walkSightRepository = walkSightRepository;
            _loggingRepository = loggingRepository;
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            IActionResult _result = new ObjectResult(false);
            GenericResult _removeResult = null;

            try
            {
                WalkSight _walkSightToRemove = this._walkSightRepository.GetSingle(id);
                this._walkSightRepository.Delete(_walkSightToRemove);
                this._walkSightRepository.Commit();

                _removeResult = new GenericResult()
                {
                    Succeeded = true,
                    Message = "Sight is removed from the walk."
                };
            }
            catch (Exception ex)
            {
                _removeResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
                _loggingRepository.Commit();
            }

            _result = new ObjectResult(_removeResult);
            return _result;
        }
    }
}