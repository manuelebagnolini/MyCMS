using MyCMS.Core.Entities;
using MyCMS.Core.Interfaces;

namespace MyCMS.Data.TestData
{
    public class TestDataImporter
    {
        IEntityRepository<Core.Entities.Attribute> _attributes;
        IEntityRepository<ContentType> _contentTypes;
        IEntityRepository<ContentRelationType> _contentRelationTypes;
        IEntityRepository<User> _users;
        IEntityRepository<Content> _contents;

        public TestDataImporter(
            IEntityRepository<Core.Entities.Attribute> attributes,
            IEntityRepository<ContentType> contentTypes,
            IEntityRepository<ContentRelationType> contentRelationTypes,
            IEntityRepository<User> users,
            IEntityRepository<Content> contents)
        {
            _attributes = attributes;
            _contentTypes = contentTypes;
            _contentRelationTypes = contentRelationTypes;
            _users = users;
            _contents = contents;
        }

        public void Import()
        {
            _attributes.RemoveRange(_attributes.Table);
            _contentTypes.RemoveRange(_contentTypes.Table);
            _contentRelationTypes.RemoveRange(_contentRelationTypes.Table);
            _users.RemoveRange(_users.Table);
            _contents.RemoveRange(_contents.Table);
            _contents.SaveChanges();

            var attributes = new List<Core.Entities.Attribute>
            {
                new Core.Entities.Attribute
                {
                    Name = "Color",
                    Description = "Select a color",
                    AttributeType = AttributeTypes.Select,
                    Options = new List<AttributeOption>
                    {
                        new AttributeOption { Value = "Red" },
                        new AttributeOption { Value = "Blue" },
                        new AttributeOption { Value = "Green" },
                        new AttributeOption { Value = "Yellow" }
                    }
                },
                new Core.Entities.Attribute
                {
                    Name = "Views",
                    Description = "Number of views",
                    AttributeType = AttributeTypes.Number
                },
                new Core.Entities.Attribute
                {
                    Name = "Last viewed",
                    Description = "Last time visit",
                    AttributeType = AttributeTypes.Date
                },
                new Core.Entities.Attribute
                {
                    Name = "Notes",
                    Description = "Notes",
                    AttributeType = AttributeTypes.Text
                },
            };

            var contentTypes = new List<ContentType>
            {
                new ContentType
                {
                    Name = "Article",
                    Description = "A main article"
                },
                new ContentType
                {
                    Name = "Image",
                    Description = "An image content"
                },
                new ContentType
                {
                    Name = "Comment",
                    Description = "A comment from a user"
                },
                new ContentType
                {
                    Name = "Page",
                    Description = "A full page content"
                }
            };

            var contentRelationTypes = new List<ContentRelationType>
            {
                new ContentRelationType
                {
                    Name = "Composition",
                    Description = "The referred content is used to compose the main content"
                },
                new ContentRelationType
                {
                    Name = "Reference",
                    Description = "The referred content is referred inside the main content"
                }
            };

            var users = new List<User>
            {
                new User
                {
                    Username = "jlittle",
                    Name = "Jeremy",
                    Surname = "Little",
                    Email = "jlittle@mycms.org"
                },
                new User
                {
                    Username = "mstrang",
                    Name = "Michael",
                    Surname = "Strang",
                    Email = "mstrang@mycms.org"
                },
                new User
                {
                    Username = "bbutcher",
                    Name = "Billy",
                    Surname = "Butcher",
                    Email = "bbutcher@mycms.org"
                },
                new User
                {
                    Username = "kreeves",
                    Name = "Keith",
                    Surname = "Reeves",
                    Email = "kreeves@mycms.org"
                }
            };

            var contents = new List<Content>
            {
                new Content
                {
                    Title = "This is just a test article",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Url = null,
                    ContentType = contentTypes[0],
                    CreateUser = users[0],
                    CreateDatetime = DateTime.Now,
                    ModifyUser = users[0],
                    ModifyDatetime = DateTime.Now,
                    Attributes = new List<ContentAttribute>
                    {
                        new ContentAttribute
                        {
                            Attribute = attributes[0],
                            AttributeOption = attributes[0].Options.Where(x => x.Value == "Green").Single(),
                        },
                        new ContentAttribute
                        {
                            Attribute = attributes[1],
                            ValueNumber = 10
                        },
                        new ContentAttribute
                        {
                            Attribute = attributes[2],
                            ValueDate = DateTime.Now
                        },
                        new ContentAttribute
                        {
                            Attribute = attributes[3],
                            ValueText = "This is just a simple note"
                        }
                    },
                }
            };

            contents.Add(new Content
            {
                Title = "This is just a test image",
                Body = null,
                Url = "https://lo2y.com/wp-content/uploads/2016/02/hello-world-510x219.png",
                ContentType = contentTypes[1],
                CreateUser = users[1],
                CreateDatetime = DateTime.Now,
                ModifyUser = users[1],
                ModifyDatetime = DateTime.Now,
                Attributes = new List<ContentAttribute>
                {
                    new ContentAttribute
                    {
                        Attribute = attributes[3],
                        ValueText = "Added image to say hello"
                    }
                },
                ReferencedBy = new List<ContentRelation>
                {
                    new ContentRelation
                    {
                        ContainerContent = contents[0],
                        ContentRelationType = contentRelationTypes[0]
                    }
                }
            });

            contents.Add(new Content
            {
                Title = "This is just a test comment",
                Body = "I don't like this Lorem ipsum thing...",
                Url = null,
                ContentType = contentTypes[2],
                CreateUser = users[2],
                CreateDatetime = DateTime.Now,
                ModifyUser = users[2],
                ModifyDatetime = DateTime.Now,
                Attributes = new List<ContentAttribute>
                {
                    new ContentAttribute
                    {
                        Attribute = attributes[0],
                        AttributeOption = attributes[0].Options.Where(x => x.Value == "Red").Single(),
                    }
                },
                ReferencedBy = new List<ContentRelation>
                {
                    new ContentRelation
                    {
                        ContainerContent = contents[0],
                        ContentRelationType = contentRelationTypes[1]
                    }
                }
            });

            contents.Add(new Content
            {
                Title = "This is just a test page",
                Body = "<p>Under construction</p>",
                Url = null,
                ContentType = contentTypes[3],
                CreateUser = users[3],
                CreateDatetime = DateTime.Now,
                ModifyUser = users[3],
                ModifyDatetime = DateTime.Now
            });


            _attributes.AddRange(attributes);
            _contentTypes.AddRange(contentTypes);
            _contentRelationTypes.AddRange(contentRelationTypes);
            _users.AddRange(users);
            _contents.AddRange(contents);
            _contents.SaveChanges();
        }
    }
}
