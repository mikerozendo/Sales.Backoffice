﻿using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Model;

public class Document : EntityBase
{
    public string Number { get; set; }
    public DocumentType DocumentType { get; set; }
    public bool IsValid { get; set; }
    public bool Validated { get; set; }
    public Agent Agent { get; set; }
    public Guid AgentId { get; set; }
}
