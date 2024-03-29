﻿using IdentityServer4.Extensions;
using RookieOnlineAssetManagement.Exceptions;
using RookieOnlineAssetManagement.Models;
using RookieOnlineAssetManagement.Repositories;
using RookieOnlineAssetManagement.Utils;
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
        public async Task<bool> ChangeStateAsync(bool accept, string assignmentId, string acceptedUserId)
        {
            return await _returnRequestRepository.ChangeStateAsync(accept, assignmentId, acceptedUserId);
        }
        public async Task<(ICollection<ReturnRequestModel> Datas, int TotalPage, int TotalItem)> GetListReturnRequestAsync(ReturnRequestParams returnRequestParams)
        {
            if (returnRequestParams.ReturnedDate != null)
            {
                var checkDate = DateTimeHelper.IsDateTime(returnRequestParams.ReturnedDate);
                if (checkDate == false)
                    throw new ServiceException("Return date not valid !");
            }
            if (returnRequestParams.Page < 0 || returnRequestParams.PageSize < 0)
            {
                throw new ServiceException("Page and Page size not valid !");
            }
            return await _returnRequestRepository.GetListReturnRequestAsync(returnRequestParams);
        }
    }
}
