using Moq;

namespace TestProject1
{
    public class SampleTest
    {
        [Test]
        public async Task Test_GetUserById()
        {
            // Arrange
            var expectedId = "1";
            var expectedName = "John Doe";
            var expectedResponse = User.GetUserByIdResponse(expectedId, expectedName);

            var mockGraphQLClient = new Mock<IGraphQLClient>();
            mockGraphQLClient
                .Setup(client => client.PostAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(expectedResponse);

            var graphQLHelper = new GraphQLHelper(mockGraphQLClient.Object);

            // Act
            var user = await graphQLHelper.GetUserById(expectedId);

            // Assert
            Assert.NotNull(user);
            Assert.Equals(expectedId, user.id);
            Assert.Equals(expectedName, user.name);
        }
    }

}