﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Domain.Common
{
	public abstract class BaseEntity<T>
	{
        public T? Id { get; set; }

		private readonly List<BaseEvent> _domainEvents = new();

		[NotMapped]
		public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

		protected void AddDomainEvent(BaseEvent domainEvent)
		{
			_domainEvents.Add(domainEvent);
		}

		protected void RemoveDomainEvent(BaseEvent domainEvent)
		{
			_domainEvents.Remove(domainEvent);
		}

		public void ClearDomainEvents()
		{
			_domainEvents.Clear();
		}
	}
}
