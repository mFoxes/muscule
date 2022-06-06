using Microsoft.AspNetCore.Mvc;
using Muscle.DataService.IConfiguration;
using Muscle.Entities.DbSet.DbSetForUserDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Controllers.UserControllers
{
    public class DocumentController : BaseController
    {
        public DocumentController(IUserUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        [HttpGet]
        [Route("GetAllDocuments", Name = "GetAllDocuments")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _userUnitOfWork.RoleRepository.GetAllAsync();
            return Ok(res);
        }

        [HttpGet]
        [Route("GetDocumentById", Name = "GetDocumentById")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _userUnitOfWork.DocumentRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        [Route("AddDocument", Name = "AddDocument")]
        public async Task<IActionResult> Add(Document document)
        {
            var res = await _userUnitOfWork.DocumentRepository.AddAsync(document);
            if (!res)
                return BadRequest("Error while adding");
            await _userUnitOfWork.Save();
            return Ok(res); //TODO Поменяй на CreatedAtRoute + добавь DTO классы
        }

        [HttpPost]
        [Route("AddRangeOfDocuments", Name = "AddRangeOfDocuments")]
        public async Task<IActionResult> AddRange(IEnumerable<Document> documents)
        {
            var res = await _userUnitOfWork.DocumentRepository.AddRangeAsync(documents);
            if (!res)
                return BadRequest("Error while adding");
            await _userUnitOfWork.Save();
            return Ok(res);
        }

        [HttpPost]
        [Route("UpdateDocument", Name = "UpdateDocument")]
        public async Task<IActionResult> Update(Document newDocument, int id)
        {
            var documentForUpdate = await _userUnitOfWork.DocumentRepository.GetByIdAsync(id);
            if (documentForUpdate == null)
                return BadRequest("Item does not exist");

            documentForUpdate.Name = newDocument.Name;
            documentForUpdate.Photo = newDocument.Photo;
            documentForUpdate.Descr = newDocument.Descr;

            var res = await _userUnitOfWork.DocumentRepository.UpdateAsync(documentForUpdate);
            if (!res)
                return BadRequest("Something went wrong");
            await _userUnitOfWork.Save();
            return Ok(res);
        }

        [HttpDelete]
        [Route("DeleteDocument", Name = "DeleteDocument")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _userUnitOfWork.DocumentRepository.DeleteAsync(id);
            if (!res)
                return BadRequest("Error while deleting");
            await _userUnitOfWork.Save();
            return Ok(res);
        }
    }
}
