using System;

public abstract class AuditableEntities
{
	public string Id { get; set;} = Guid.NewGuid().ToString().Substring(0,5);
    
}
