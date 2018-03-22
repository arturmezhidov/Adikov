using System;
using System.Collections.Generic;
using System.Linq;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;

namespace Adikov.Domain.Queries.Faq
{
    public class FaqRequestDetail
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public FaqRequestStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string AvatarLink { get; set; }
    }

    public class FaqRequests
    {
        public IEnumerable<FaqRequestDetail> PendingRequests { get; set; }

        public IEnumerable<FaqRequestDetail> ApprovedRequests { get; set; }
    }

    public class FindFaqRequestsQueryResult
    {
        public FaqRequests Requests { get; set; }
    }

    public class FindFaqRequestsQuery : Query<EmptyCriterion, FindFaqRequestsQueryResult>
    {
        protected override FindFaqRequestsQueryResult OnExecuting(EmptyCriterion criterion)
        {
            List<FaqRequest> requests = DataContext.FaqRequests.AsNoTracking().Where(i => !i.IsDeleted).OrderByDescending(i => i.CreatedAt).ToList();
            List<FaqRequestDetail> requestDetails = new List<FaqRequestDetail>();

            foreach (FaqRequest request in requests)
            {
                FaqRequestDetail requestDetail = new FaqRequestDetail
                {
                    Id = request.Id,
                    Question = request.Question,
                    Status = request.Status,
                    CreatedAt = request.CreatedAt,
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

                requestDetails.Add(requestDetail);
            }

            FindFaqRequestsQueryResult result = new FindFaqRequestsQueryResult
            {
                Requests = new FaqRequests
                {
                    PendingRequests = requestDetails.Where(i => i.Status != FaqRequestStatus.Confirmed),
                    ApprovedRequests = requestDetails.Where(i => i.Status == FaqRequestStatus.Confirmed)
                }
            };

            return result;
        }

    }
}