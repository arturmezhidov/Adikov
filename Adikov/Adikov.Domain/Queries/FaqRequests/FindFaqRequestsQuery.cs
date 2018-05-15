using System;
using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;

namespace Adikov.Domain.Queries.FaqRequests
{
    public class FaqRequestDetail
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public FaqRequestStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string AvatarLink { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class FaqRequests
    {
        public IEnumerable<FaqRequestDetail> PendingRequests { get; set; }

        public IEnumerable<FaqRequestDetail> ApprovedRequests { get; set; }

        public IEnumerable<FaqRequestDetail> DeletedRequests { get; set; }

        public int OpenRequestsCount { get; set; }

        public int DeclinedRequestsCount { get; set; }

        public int ApprovedRequestsCount { get; set; }

        public int DeletedRequestsCount { get; set; }
    }

    public class FindFaqRequestsQueryResult
    {
        public FaqRequests Requests { get; set; }
    }

    public class FindFaqRequestsQuery : Query<EmptyCriterion, FindFaqRequestsQueryResult>
    {
        protected override FindFaqRequestsQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<FaqRequest> requests = DataContext.FaqRequests.AsNoTracking().OrderByDescending(i => i.CreatedAt).ToList();

            FindFaqRequestsQueryResult result = new FindFaqRequestsQueryResult
            {
                Requests = new FaqRequests
                {
                    PendingRequests = requests.Where(i => !i.IsDeleted && i.Status != FaqRequestStatus.Confirmed).Select(ToDetauls),
                    ApprovedRequests = requests.Where(i => !i.IsDeleted && i.Status == FaqRequestStatus.Confirmed).Select(ToDetauls),
                    DeletedRequests = requests.Where(i => i.IsDeleted).Select(ToDetauls)
                }
            };

            result.Requests.OpenRequestsCount = result.Requests.PendingRequests.Count(i => i.Status == FaqRequestStatus.Open);
            result.Requests.DeclinedRequestsCount = result.Requests.PendingRequests.Count(i => i.Status ==  FaqRequestStatus.Declined);
            result.Requests.ApprovedRequestsCount = result.Requests.ApprovedRequests.Count();
            result.Requests.DeletedRequestsCount = result.Requests.DeletedRequests.Count();

            return result;
        }

        protected FaqRequestDetail ToDetauls(FaqRequest request)
        {
            FaqRequestDetail requestDetail = new FaqRequestDetail
            {
                Id = request.Id,
                Question = request.Question,
                Status = request.Status,
                CreatedAt = request.CreatedAt,
                IsDeleted = request.IsDeleted,
                AvatarLink = PlatformConfiguration.DefaultAvatarPath
            };

            if (!String.IsNullOrEmpty(request.UserId))
            {
                ApplicationUser user = DataContext.Users.Find(request.UserId);

                if (user != null)
                {
                    requestDetail.CreatedBy = String.Format("{0} {1}", user.LastName, user.FirstName);

                    if (String.IsNullOrWhiteSpace(requestDetail.CreatedBy))
                    {
                        requestDetail.CreatedBy = user.UserName;
                    }
                }
            }

            if (String.IsNullOrEmpty(requestDetail.CreatedBy))
            {
                requestDetail.CreatedBy = "Неизвестный автор";
            }

            return requestDetail;
        }
    }
}