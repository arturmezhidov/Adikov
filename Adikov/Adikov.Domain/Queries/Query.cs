﻿using System;
using Adikov.Domain.Data;
using Adikov.Domain.Models;
using Adikov.Infrastructura.Criterion;
using Adikov.Infrastructura.Queries;
using Adikov.Platform.Configuration;

namespace Adikov.Domain.Queries
{
    public abstract class Query<TCriterion, TResponse> : QueryBase<TCriterion, TResponse> where TCriterion : ICriterion where TResponse : class 
    {
        protected ApplicationDbContext DataContext { get; }

        protected Query()
        {
            DataContext = ApplicationDbContext.Create();
        }

        protected virtual string GetFileUrl(File file, string template = null)
        {
            if (file == null)
            {
                return String.Empty;
            }

            return String.Format(template ?? PlatformConfiguration.UploadedSettingsPathTemplate, UserContext.UserId, file.PhysicalName);
        }

        protected virtual File GetFile(string id)
        {
            if (int.TryParse(id, out var fileId))
            {
                return GetFile(fileId);
            }
            return null;
        }

        protected virtual File GetFile(int id)
        {
            return DataContext.Files.Find(id);
        }
    }
}