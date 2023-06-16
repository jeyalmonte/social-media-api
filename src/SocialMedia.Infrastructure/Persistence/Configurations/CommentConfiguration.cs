﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Infrastructure.Persistence.Configurations
{
	public class CommentConfiguration : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.ToTable("Comments");

			builder.HasKey(c => c.Id); 

			builder.Property(c => c.Description)
				.HasMaxLength(500);

			builder.Property(c => c.Date);

			builder.HasOne(c => c.Post)
				.WithMany(p => p.Comments)
				.HasForeignKey(c => c.PostId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(c => c.User)
			.WithMany(u => u.Comments)
			.HasForeignKey(c => c.UserId)
			.OnDelete(DeleteBehavior.Restrict);

		}
	}
}