namespace LinkedIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Address_id = c.Int(nullable: false, identity: true),
                        member_id = c.Int(),
                        line_1 = c.String(maxLength: 50),
                        line_2 = c.String(maxLength: 50),
                        line_3 = c.String(maxLength: 50),
                        city = c.String(nullable: false, maxLength: 50),
                        state_country_province = c.String(nullable: false, maxLength: 50),
                        zip_or_postcode = c.String(maxLength: 50),
                        country = c.String(nullable: false, maxLength: 50),
                        other_details = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Address_id)
                .ForeignKey("dbo.Members", t => t.member_id)
                .Index(t => t.member_id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        member_id = c.Int(nullable: false, identity: true),
                        current_organization_id = c.Int(),
                        marital_status_description = c.String(maxLength: 50),
                        date_joined = c.DateTime(storeType: "date"),
                        date_of_birth = c.DateTime(storeType: "date"),
                        email_address = c.String(nullable: false),
                        email_password = c.String(nullable: false, maxLength: 50),
                        first_name = c.String(nullable: false, maxLength: 50),
                        middle_name = c.String(maxLength: 50),
                        last_name = c.String(nullable: false, maxLength: 50),
                        gender = c.String(maxLength: 50),
                        other_details = c.String(unicode: false, storeType: "text"),
                        profile_image = c.String(),
                        Organization_organization_id = c.Int(),
                    })
                .PrimaryKey(t => t.member_id)
                .ForeignKey("dbo.Organizations", t => t.Organization_organization_id)
                .Index(t => t.Organization_organization_id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        comment_id = c.Int(nullable: false),
                        member_id = c.Int(nullable: false),
                        post_id = c.Int(nullable: false),
                        comment_content = c.String(),
                    })
                .PrimaryKey(t => new { t.comment_id, t.member_id, t.post_id })
                .ForeignKey("dbo.Members", t => t.member_id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.post_id, cascadeDelete: true)
                .Index(t => t.member_id)
                .Index(t => t.post_id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        post_id = c.Int(nullable: false),
                        post_content = c.String(),
                        member_id = c.Int(),
                    })
                .PrimaryKey(t => t.post_id)
                .ForeignKey("dbo.Members", t => t.member_id)
                .Index(t => t.member_id);
            
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        connection_id = c.Int(nullable: false, identity: true),
                        connection_member_id = c.Int(),
                        member_id = c.Int(),
                        date_connection_made = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.connection_id)
                .ForeignKey("dbo.Members", t => t.connection_member_id)
                .ForeignKey("dbo.Members", t => t.member_id)
                .Index(t => t.connection_member_id)
                .Index(t => t.member_id);
            
            CreateTable(
                "dbo.CVs",
                c => new
                    {
                        cv_id = c.Int(nullable: false, identity: true),
                        member_id = c.Int(),
                        date_created = c.DateTime(storeType: "date"),
                        date_updated = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.cv_id)
                .ForeignKey("dbo.Members", t => t.member_id)
                .Index(t => t.member_id);
            
            CreateTable(
                "dbo.CV_Sections",
                c => new
                    {
                        cv_section_id = c.Int(nullable: false, identity: true),
                        cv_id = c.Int(),
                        cv_section_code = c.Int(),
                        date_created = c.DateTime(storeType: "date"),
                        date_updated = c.DateTime(storeType: "date"),
                        cv_section_text = c.String(),
                    })
                .PrimaryKey(t => t.cv_section_id)
                .ForeignKey("dbo.CVs", t => t.cv_id)
                .ForeignKey("dbo.Ref_CV_Sections", t => t.cv_section_code)
                .Index(t => t.cv_id)
                .Index(t => t.cv_section_code);
            
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        member_id = c.Int(),
                        cv_section_id = c.Int(),
                        school_name = c.String(nullable: false, maxLength: 50),
                        school_location = c.String(nullable: false, maxLength: 50),
                        start_date = c.DateTime(nullable: false, storeType: "date"),
                        end_date = c.DateTime(nullable: false, storeType: "date"),
                        other_details = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CV_Sections", t => t.cv_section_id)
                .ForeignKey("dbo.Members", t => t.member_id)
                .Index(t => t.member_id)
                .Index(t => t.cv_section_id);
            
            CreateTable(
                "dbo.Experience",
                c => new
                    {
                        experience_id = c.Int(nullable: false, identity: true),
                        member_id = c.Int(),
                        cv_section_id = c.Int(),
                        title = c.String(nullable: false),
                        company_name = c.String(nullable: false),
                        company_location = c.String(nullable: false),
                        description = c.String(unicode: false, storeType: "text"),
                        start_date = c.DateTime(nullable: false, storeType: "date"),
                        end_date = c.DateTime(nullable: false, storeType: "date"),
                        other_details = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.experience_id)
                .ForeignKey("dbo.CV_Sections", t => t.cv_section_id)
                .ForeignKey("dbo.Members", t => t.member_id)
                .Index(t => t.member_id)
                .Index(t => t.cv_section_id);
            
            CreateTable(
                "dbo.Ref_CV_Sections",
                c => new
                    {
                        cv_section_code = c.Int(nullable: false, identity: true),
                        cv_section_description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.cv_section_code);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        group_id = c.Int(nullable: false, identity: true),
                        created_by_member_id = c.Int(),
                        group_name = c.String(maxLength: 50),
                        group_description = c.String(maxLength: 50),
                        group_date_started = c.DateTime(storeType: "date"),
                        group_date_ended = c.DateTime(storeType: "date"),
                        group_date_last_activity = c.DateTime(storeType: "date"),
                        other_details = c.String(),
                        Member_member_id = c.Int(),
                    })
                .PrimaryKey(t => t.group_id)
                .ForeignKey("dbo.Members", t => t.Member_member_id)
                .Index(t => t.Member_member_id);
            
            CreateTable(
                "dbo.Members_Groups",
                c => new
                    {
                        member_id = c.Int(nullable: false),
                        group_id = c.Int(nullable: false),
                        date_joined = c.DateTime(storeType: "date"),
                        date_left = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => new { t.member_id, t.group_id })
                .ForeignKey("dbo.Groups", t => t.group_id, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.member_id, cascadeDelete: true)
                .Index(t => t.member_id)
                .Index(t => t.group_id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        message_id = c.Int(nullable: false),
                        member_sender_id = c.Int(nullable: false),
                        member_receiver_id = c.Int(nullable: false),
                        message_content = c.String(),
                    })
                .PrimaryKey(t => new { t.message_id, t.member_sender_id, t.member_receiver_id })
                .ForeignKey("dbo.Members", t => t.member_receiver_id)
                .ForeignKey("dbo.Members", t => t.member_sender_id)
                .Index(t => t.member_sender_id)
                .Index(t => t.member_receiver_id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        organization_id = c.Int(nullable: false, identity: true),
                        organization_name = c.String(maxLength: 50),
                        organization_description = c.String(),
                        other_details = c.String(),
                    })
                .PrimaryKey(t => t.organization_id);
            
            CreateTable(
                "dbo.People_Being_Followed",
                c => new
                    {
                        member_id = c.Int(nullable: false),
                        member_being_followed_id = c.Int(nullable: false),
                        date_start_following = c.DateTime(nullable: false, storeType: "date"),
                        date_stopped_following = c.DateTime(storeType: "date"),
                        other_details = c.String(),
                    })
                .PrimaryKey(t => new { t.member_id, t.member_being_followed_id, t.date_start_following })
                .ForeignKey("dbo.Members", t => t.member_being_followed_id)
                .ForeignKey("dbo.Members", t => t.member_id)
                .Index(t => t.member_id)
                .Index(t => t.member_being_followed_id);
            
            CreateTable(
                "dbo.Recommendations",
                c => new
                    {
                        member_recommending_id = c.Int(nullable: false),
                        member_being_recommended_id = c.Int(nullable: false),
                        date_of_recommendation = c.DateTime(storeType: "date"),
                        other_details = c.String(),
                    })
                .PrimaryKey(t => new { t.member_recommending_id, t.member_being_recommended_id })
                .ForeignKey("dbo.Members", t => t.member_being_recommended_id)
                .ForeignKey("dbo.Members", t => t.member_recommending_id)
                .Index(t => t.member_recommending_id)
                .Index(t => t.member_being_recommended_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recommendations", "member_recommending_id", "dbo.Members");
            DropForeignKey("dbo.Recommendations", "member_being_recommended_id", "dbo.Members");
            DropForeignKey("dbo.People_Being_Followed", "member_id", "dbo.Members");
            DropForeignKey("dbo.People_Being_Followed", "member_being_followed_id", "dbo.Members");
            DropForeignKey("dbo.Members", "Organization_organization_id", "dbo.Organizations");
            DropForeignKey("dbo.Messages", "member_sender_id", "dbo.Members");
            DropForeignKey("dbo.Messages", "member_receiver_id", "dbo.Members");
            DropForeignKey("dbo.Groups", "Member_member_id", "dbo.Members");
            DropForeignKey("dbo.Members_Groups", "member_id", "dbo.Members");
            DropForeignKey("dbo.Members_Groups", "group_id", "dbo.Groups");
            DropForeignKey("dbo.CVs", "member_id", "dbo.Members");
            DropForeignKey("dbo.CV_Sections", "cv_section_code", "dbo.Ref_CV_Sections");
            DropForeignKey("dbo.Experience", "member_id", "dbo.Members");
            DropForeignKey("dbo.Experience", "cv_section_id", "dbo.CV_Sections");
            DropForeignKey("dbo.Education", "member_id", "dbo.Members");
            DropForeignKey("dbo.Education", "cv_section_id", "dbo.CV_Sections");
            DropForeignKey("dbo.CV_Sections", "cv_id", "dbo.CVs");
            DropForeignKey("dbo.Connections", "member_id", "dbo.Members");
            DropForeignKey("dbo.Connections", "connection_member_id", "dbo.Members");
            DropForeignKey("dbo.Posts", "member_id", "dbo.Members");
            DropForeignKey("dbo.Comments", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Comments", "member_id", "dbo.Members");
            DropForeignKey("dbo.Addresses", "member_id", "dbo.Members");
            DropIndex("dbo.Recommendations", new[] { "member_being_recommended_id" });
            DropIndex("dbo.Recommendations", new[] { "member_recommending_id" });
            DropIndex("dbo.People_Being_Followed", new[] { "member_being_followed_id" });
            DropIndex("dbo.People_Being_Followed", new[] { "member_id" });
            DropIndex("dbo.Messages", new[] { "member_receiver_id" });
            DropIndex("dbo.Messages", new[] { "member_sender_id" });
            DropIndex("dbo.Members_Groups", new[] { "group_id" });
            DropIndex("dbo.Members_Groups", new[] { "member_id" });
            DropIndex("dbo.Groups", new[] { "Member_member_id" });
            DropIndex("dbo.Experience", new[] { "cv_section_id" });
            DropIndex("dbo.Experience", new[] { "member_id" });
            DropIndex("dbo.Education", new[] { "cv_section_id" });
            DropIndex("dbo.Education", new[] { "member_id" });
            DropIndex("dbo.CV_Sections", new[] { "cv_section_code" });
            DropIndex("dbo.CV_Sections", new[] { "cv_id" });
            DropIndex("dbo.CVs", new[] { "member_id" });
            DropIndex("dbo.Connections", new[] { "member_id" });
            DropIndex("dbo.Connections", new[] { "connection_member_id" });
            DropIndex("dbo.Posts", new[] { "member_id" });
            DropIndex("dbo.Comments", new[] { "post_id" });
            DropIndex("dbo.Comments", new[] { "member_id" });
            DropIndex("dbo.Members", new[] { "Organization_organization_id" });
            DropIndex("dbo.Addresses", new[] { "member_id" });
            DropTable("dbo.Recommendations");
            DropTable("dbo.People_Being_Followed");
            DropTable("dbo.Organizations");
            DropTable("dbo.Messages");
            DropTable("dbo.Members_Groups");
            DropTable("dbo.Groups");
            DropTable("dbo.Ref_CV_Sections");
            DropTable("dbo.Experience");
            DropTable("dbo.Education");
            DropTable("dbo.CV_Sections");
            DropTable("dbo.CVs");
            DropTable("dbo.Connections");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Members");
            DropTable("dbo.Addresses");
        }
    }
}
