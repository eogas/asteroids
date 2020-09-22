using System;
using System.Linq;
using Xunit;

namespace Asteroids.Test
{
    public class AsteroidsTests
    {
        [Fact]
        public void Asteroids_ReturnsEmpty_WithNull()
        {
            // arrange
            var expected = Enumerable.Empty<int>();

            // act
            var result = Program.Asteroids(null);

            // assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Asteroids_ReturnsSameSet_WithAllMovingSameDirection()
        {
            // arrange
            var input = new [] { 1, 2, 3, 4, 5 };
            var expected = new [] { 1, 2, 3, 4, 5 };

            // act
            var result = Program.Asteroids(input);

            // assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Asteroids_ReturnsOne_WithTwoAsteroidsOneCollision()
        {
            // arrange
            var input = new [] { 1, -4 };
            var expected = new [] { -4 };

            // act
            var result = Program.Asteroids(input);

            // assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Asteroids_ReturnsEmpty_ForWorstCase()
        {
            // arrange
            var input = new [] { 9, 8, 7, 6, 5, 4, 3, 2, 1, -9 };
            var expected = new int[] { };

            // act
            var result = Program.Asteroids(input);

            // assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Asteroids_ReturnsSameSet_NoCollisions()
        {
            // arrange
            var input = new [] { -1, 2 };
            var expected = new [] { -1, 2 };

            // act
            var result = Program.Asteroids(input);

            // assert
            Assert.Equal(expected, result);
        }
    }
}
