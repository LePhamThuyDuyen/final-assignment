﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RookieOnlineAssetManagement.Enums;
using RookieOnlineAssetManagement.Models;
using RookieOnlineAssetManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieOnlineAssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentsController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
        [HttpPost]
        public async Task<ActionResult<AssignmentModel>> CreateAsync(AssignmentRequestModel assignmentRequestModel)
        {
            return Ok(await _assignmentService.CreateAssignmentAsync(assignmentRequestModel));
        }
        [HttpPut("{id})")]
        public async Task<ActionResult<AssignmentModel>> UpdateAsync(string id,AssignmentRequestModel assignmentRequestModel)
        {
            return Ok(await _assignmentService.UpdateAssignmentAsync(id, assignmentRequestModel));
        }
        [HttpPut("changestate/{id}")]
        public async Task<ActionResult<bool>> ChangeStateAsync(string id, StateAssignment state)
        {
            return Ok(await _assignmentService.ChangeStateAssignmentAsync(id, state));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(string id)
        {
            return Ok( await _assignmentService.DeleteAssignmentAsync(id));
        }
        [HttpGet("myassignments")]
        public async Task<ActionResult<MyAssigmentModel>> GetMyListAsync(string userid, string locationid, SortBy? AssetIdSort, SortBy? AssetNameSort, SortBy? CategoryNameSort, SortBy? AssignedDateSort, SortBy? StateSort)
        {
            return Ok(await _assignmentService.GetListMyAssignmentAsync(userid, locationid, AssetIdSort, AssetNameSort, CategoryNameSort, AssignedDateSort, StateSort));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentModel>>> GetListAsync([FromQuery] AssignmentRequestParams assignmentRequestParams)
        {
            var result = await _assignmentService.GetListAssignmentAsync(assignmentRequestParams);
            HttpContext.Response.Headers.Add("total-pages", result.TotalPage.ToString());
            HttpContext.Response.Headers.Add("total-item", result.TotalItem.ToString());
            return Ok(result.Datas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentDetailModel>> GetAssignmentById(string id)
        {
            return Ok(await _assignmentService.GetAssignmentById(id));
        }
    }
}
