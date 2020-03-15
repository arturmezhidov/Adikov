using System;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;

namespace Adikov.Domain.Queries.FaqRequests
{
    public class FindFaqRequestByIdQueryResult
    {
        public FaqRequestDetail RequestDetail { get; set; }
    }

    public class FindFaqRequestByIdQuery : Query<IdCriterion, FindFaqRequestByIdQueryResult>
    {
        protected override FindFaqRequestByIdQueryResult OnExecuting(IdCriterion criterion)
        {
            FaqRequest request = DataContext.FaqRequests.Find(criterion.Id);

            FindFaqRequestByIdQueryResult result = new FindFaqRequestByIdQueryResult
            {
                RequestDetail = ToDetauls(request)
            };

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

            return requestDetail;
        }
    }
}