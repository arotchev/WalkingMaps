using System;
using Microsoft.AspNetCore.Mvc;
using WalkingMaps.Infrastructure.Repositories.Abstract;
using WalkingMaps.Infrastructure.Core;
using WalkingMaps.Entities;

namespace WalkingMaps.Controllers
{
    [Route("api/[controller]")]
    public class SightsController : Controller
    {
        ISightRepository _sightRepository;
        ILoggingRepository _loggingRepository;

        public SightsController(ISightRepository sightRepository, ILoggingRepository loggingRepository)
        {
            _sightRepository = sightRepository;
            _loggingRepository = loggingRepository;
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            IActionResult _result = new ObjectResult(false);
            GenericResult _removeResult = null;

            try
            {
                Sight _sightToRemove = this._sightRepository.GetSingle(id);
                this._sightRepository.Delete(_sightToRemove);
                this._sightRepository.Commit();

                _removeResult = new GenericResult()
                {
                    Succeeded = true,
                    Message = "Sight is removed."
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