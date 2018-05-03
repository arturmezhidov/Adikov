using Adikov.Domain.Models;
using Adikov.Domain.Queries.Settings;
using Adikov.Infrastructura.Criterion;
using Adikov.Platform.Configuration;
using Adikov.Platform.Settings;

namespace Adikov.Domain.Queries.Contacts
{
    public class GetDocumentsQueryResult
    {
        public ContactsDocuments Documents { get; set; }

        public string DocumentsLink { get; set; }

        public string FileName { get; set; }
    }

    public class GetDocumentsQuery : BaseSettingsQuery<EmptyCriterion, GetDocumentsQueryResult>
    {
        protected override GetDocumentsQueryResult OnExecuting(EmptyCriterion criterion)
        {
            GetDocumentsQueryResult result = new GetDocumentsQueryResult
            {
                Documents = GetSettings<ContactsDocuments>()
            };

            File file = GetFile(result.Documents.FileId);

            if(file != null)
            {
                result.DocumentsLink = string.Format(PlatformConfiguration.DocumentsPathTemplate, file.PhysicalName);
                result.FileName = file.PhysicalName;
            }

            return result;
        }

        public static GetDocumentsQueryResult Execute()
        {
            return new GetDocumentsQuery().Execute(new EmptyCriterion());
        }
    }
}