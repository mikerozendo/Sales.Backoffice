﻿using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Model.Enums;
using Sales.Backoffice.Model;

namespace Sales.Backoffice.Application.Mappers;

public static class DocumentMapper
{
    public static List<Document> ToModel(this List<CreateDocumentRequest> documents)
    {
        return documents.Select(x => new Document()
        {
            DocumentType = (DocumentType)x.DocumentType,
            Number = x.Number,
            Validated = false,
        })
        .ToList();
    }
}
