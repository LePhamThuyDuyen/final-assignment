﻿using RookieOnlineAssetManagement.Models;
using RookieOnlineAssetManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieOnlineAssetManagement.Services
{
    public class ReturnRequestService : IReturnRequestService
    {
        private readonly IReturnRequestRepository _returnRequestRepository;
        public ReturnRequestService(IReturnRequestRepository returnRequestRepository)
        {
            _returnRequestRepository = returnRequestRepository;
        }
        public async Task<ReturnRequestModel> CreateReturnRequestAsync(string assignmentId, string requestedUserId)
        {
            return await _returnRequestRepository.CreateReturnRequestAsync(assignmentId, requestedUserId);
        }
        public async Task<bool> ChangeStateAsync(bool state, string assignmentId)
        {
            return await _returnRequestRepository.ChangeStateAsync(state, assignmentId);
        }
        public async Task<ICollection<ReturnRequestModel>> GetListReturnRequestAsync(ReturnRequestParams returnRequestParams)
        {
            return await _returnRequestRepository.GetListReturnRequestAsync(returnRequestParams);
        }
    }
}
