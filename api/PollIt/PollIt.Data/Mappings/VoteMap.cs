using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollIt.Core;

namespace PollIt.Data.Mappings
{
    public class VoteMap : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("tVote");

            builder.HasKey(x => x.VoteId);

            builder.HasOne(a => a.QuestionOption)
                   .WithMany(b => b.Votes)
                   .HasForeignKey(c => c.QuestionOptionId)
                   .IsRequired();
        }
    }
}
