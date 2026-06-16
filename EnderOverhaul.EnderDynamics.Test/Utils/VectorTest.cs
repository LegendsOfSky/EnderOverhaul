using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderDynamics.Test.Utils;

/// <summary>
///     The vector test is introduced because Mojang may change how vector operations work by introducing floating point casting and floating point errors.
///     Therefore, it is essential to test all those vector behaviours such that it strictly follows how Minecraft calculates them.
/// </summary>
/// <remarks> Notes:
///     <list type="bullet">
///         <item>
///             It should be noted that some of the test is just a dummy test at this moment. In future moment, if there is any modification related to vectors,
///             additional test case will be added to ensure this library produces the same result as the actual game mechanism.
///         </item>
///     </list>
/// </remarks>
public class VectorTest
{
    [Fact]
    public void TestVectorEquality()
    {
        Vector2D vec2DZeroA = new Vector2D(0 , 0);
        Vector2D vec2DZeroB = new Vector2D(0 , 0);
        Assert.True(vec2DZeroA.Equals(vec2DZeroB));
        Assert.True(vec2DZeroB.Equals(vec2DZeroA));
        Assert.True(vec2DZeroA == vec2DZeroB);
        Assert.True(vec2DZeroB == vec2DZeroA);
        Assert.False(vec2DZeroA != vec2DZeroB);
        Assert.False(vec2DZeroB != vec2DZeroA);

        Vector2I vec2IZeroA = new Vector2I(0 , 0);
        Vector2I vec2IZeroB = new Vector2I(0 , 0);
        Assert.True(vec2IZeroA.Equals(vec2IZeroB));
        Assert.True(vec2IZeroB.Equals(vec2IZeroA));
        Assert.True(vec2IZeroA == vec2IZeroB);
        Assert.True(vec2IZeroB == vec2IZeroA);
        Assert.False(vec2IZeroA != vec2IZeroB);
        Assert.False(vec2IZeroB != vec2IZeroA);

        Vector3D vec3DZeroA = new Vector3D(0 , 0 , 0);
        Vector3D vec3DZeroB = new Vector3D(0 , 0 , 0);
        Assert.True(vec3DZeroA.Equals(vec3DZeroB));
        Assert.True(vec3DZeroB.Equals(vec3DZeroA));
        Assert.True(vec3DZeroA == vec3DZeroB);
        Assert.True(vec3DZeroB == vec3DZeroA);
        Assert.False(vec3DZeroA != vec3DZeroB);
        Assert.False(vec3DZeroB != vec3DZeroA);

        Vector3I vec3IZeroA = new Vector3I(0 , 0 , 0);
        Vector3I vec3IZeroB = new Vector3I(0 , 0 , 0);
        Assert.True(vec3IZeroA.Equals(vec3IZeroB));
        Assert.True(vec3IZeroB.Equals(vec3IZeroA));
        Assert.True(vec3IZeroA == vec3IZeroB);
        Assert.True(vec3IZeroB == vec3IZeroA);
        Assert.False(vec3IZeroA != vec3IZeroB);
        Assert.False(vec3IZeroB != vec3IZeroA);


        Vector2D vec2DPosOneA = new Vector2D(1 , 1);
        Vector2D vec2DPosOneB = new Vector2D(1 , 1);
        Assert.True(vec2DPosOneA.Equals(vec2DPosOneB));
        Assert.True(vec2DPosOneB.Equals(vec2DPosOneA));
        Assert.True(vec2DPosOneA == vec2DPosOneB);
        Assert.True(vec2DPosOneB == vec2DPosOneA);
        Assert.False(vec2DPosOneA != vec2DPosOneB);
        Assert.False(vec2DPosOneB != vec2DPosOneA);

        Vector2I vec2IPosOneA = new Vector2I(1 , 1);
        Vector2I vec2IPosOneB = new Vector2I(1 , 1);
        Assert.True(vec2IPosOneA.Equals(vec2IPosOneB));
        Assert.True(vec2IPosOneB.Equals(vec2IPosOneA));
        Assert.True(vec2IPosOneA == vec2IPosOneB);
        Assert.True(vec2IPosOneB == vec2IPosOneA);
        Assert.False(vec2IPosOneA != vec2IPosOneB);
        Assert.False(vec2IPosOneB != vec2IPosOneA);

        Vector3D vec3DPosOneA = new Vector3D(1 , 1 , 1);
        Vector3D vec3DPosOneB = new Vector3D(1 , 1 , 1);
        Assert.True(vec3DPosOneA.Equals(vec3DPosOneB));
        Assert.True(vec3DPosOneB.Equals(vec3DPosOneA));
        Assert.True(vec3DPosOneA == vec3DPosOneB);
        Assert.True(vec3DPosOneB == vec3DPosOneA);

        Vector3I vec3IPosOneA = new Vector3I(1 , 1 , 1);
        Vector3I vec3IPosOneB = new Vector3I(1 , 1 , 1);
        Assert.True(vec3IPosOneA.Equals(vec3IPosOneB));
        Assert.True(vec3IPosOneB.Equals(vec3IPosOneA));
        Assert.True(vec3IPosOneA == vec3IPosOneB);
        Assert.True(vec3IPosOneB == vec3IPosOneA);
        Assert.False(vec3IPosOneA != vec3IPosOneB);
        Assert.False(vec3IPosOneB != vec3IPosOneA);


        Vector2D vec2DNegOneA = new Vector2D(-1 , -1);
        Vector2D vec2DNegOneB = new Vector2D(-1 , -1);
        Assert.True(vec2DNegOneA.Equals(vec2DNegOneB));
        Assert.True(vec2DNegOneB.Equals(vec2DNegOneA));
        Assert.True(vec2DNegOneA == vec2DNegOneB);
        Assert.True(vec2DNegOneB == vec2DNegOneA);
        Assert.False(vec2DNegOneA != vec2DNegOneB);
        Assert.False(vec2DNegOneB != vec2DNegOneA);

        Vector2I vec2INegOneA = new Vector2I(-1 , -1);
        Vector2I vec2INegOneB = new Vector2I(-1 , -1);
        Assert.True(vec2INegOneA.Equals(vec2INegOneB));
        Assert.True(vec2INegOneB.Equals(vec2INegOneA));
        Assert.True(vec2INegOneA == vec2INegOneB);
        Assert.True(vec2INegOneB == vec2INegOneA);
        Assert.False(vec2INegOneA != vec2INegOneB);
        Assert.False(vec2INegOneB != vec2INegOneA);

        Vector3D vec3DNegOneA = new Vector3D(-1 , -1 , -1);
        Vector3D vec3DNegOneB = new Vector3D(-1 , -1 , -1);
        Assert.True(vec3DNegOneA.Equals(vec3DNegOneB));
        Assert.True(vec3DNegOneB.Equals(vec3DNegOneA));
        Assert.True(vec3DNegOneA == vec3DNegOneB);
        Assert.True(vec3DNegOneB == vec3DNegOneA);
        Assert.False(vec3DNegOneA != vec3DNegOneB);
        Assert.False(vec3DNegOneB != vec3DNegOneA);

        Vector3I vec3INegOneA = new Vector3I(-1 , -1 , -1);
        Vector3I vec3INegOneB = new Vector3I(-1 , -1 , -1);
        Assert.True(vec3INegOneA.Equals(vec3INegOneB));
        Assert.True(vec3INegOneB.Equals(vec3INegOneA));
        Assert.True(vec3INegOneA == vec3INegOneB);
        Assert.True(vec3INegOneB == vec3INegOneA);
        Assert.False(vec3INegOneA != vec3INegOneB);
        Assert.False(vec3INegOneB != vec3INegOneA);


        Assert.False(vec2DZeroA   == vec2DPosOneA);
        Assert.False(vec2DPosOneA == vec2DNegOneA);
        Assert.False(vec2DNegOneA == vec2DZeroA  );
        Assert.True(vec2DZeroA   != vec2DPosOneA);
        Assert.True(vec2DPosOneA != vec2DNegOneA);
        Assert.True(vec2DNegOneA != vec2DZeroA  );

        Assert.False(vec2IZeroA   == vec2IPosOneA);
        Assert.False(vec2IPosOneA == vec2INegOneA);
        Assert.False(vec2INegOneA == vec2IZeroA  );
        Assert.True(vec2IZeroA   != vec2IPosOneA);
        Assert.True(vec2IPosOneA != vec2INegOneA);
        Assert.True(vec2INegOneA != vec2IZeroA  );

        Assert.False(vec3DZeroA   == vec3DPosOneA);
        Assert.False(vec3DPosOneA == vec3DNegOneA);
        Assert.False(vec3DNegOneA == vec3DZeroA  );
        Assert.True(vec3DZeroA   != vec3DPosOneA);
        Assert.True(vec3DPosOneA != vec3DNegOneA);
        Assert.True(vec3DNegOneA != vec3DZeroA  );

        Assert.False(vec3IZeroA   == vec3IPosOneA);
        Assert.False(vec3IPosOneA == vec3INegOneA);
        Assert.False(vec3INegOneA == vec3IZeroA  );
        Assert.True(vec3IZeroA   != vec3IPosOneA);
        Assert.True(vec3IPosOneA != vec3INegOneA);
        Assert.True(vec3INegOneA != vec3IZeroA  );
    }



    #region Test vector nagation
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(double.MaxValue)]
    [InlineData(double.Epsilon)]
    public void TestVector2DNegation(double entry)
    {
        Vector2D negNegVec = new Vector2D(-entry , -entry);
        Vector2D negPosVec = new Vector2D(-entry , +entry);
        Vector2D posNegVec = new Vector2D(+entry , -entry);
        Vector2D posPosVec = new Vector2D(+entry , +entry);
        Assert.Equal(posPosVec , -negNegVec);
        Assert.Equal(posNegVec , -negPosVec);
        Assert.Equal(negPosVec , -posNegVec);
        Assert.Equal(negNegVec , -posPosVec);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(int.MaxValue)]
    public void TestVector2INegation(int entry)
    {
        Vector2I negNegOne = new Vector2I(-entry , -entry);
        Vector2I negPosOne = new Vector2I(-entry , +entry);
        Vector2I posNegOne = new Vector2I(+entry , -entry);
        Vector2I posPosOne = new Vector2I(+entry , +entry);
        Assert.Equal(posPosOne , -negNegOne);
        Assert.Equal(posNegOne , -negPosOne);
        Assert.Equal(negPosOne , -posNegOne);
        Assert.Equal(negNegOne , -posPosOne);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(double.MaxValue)]
    [InlineData(double.Epsilon)]
    public void TestVector3DNegation(double entry)
    {
        Vector3D negNegNegVec = new Vector3D(-entry , -entry , -entry);
        Vector3D negNegPosVec = new Vector3D(-entry , -entry , +entry);
        Vector3D negPosNegVec = new Vector3D(-entry , +entry , -entry);
        Vector3D negPosPosVec = new Vector3D(-entry , +entry , +entry);
        Vector3D posNegNegVec = new Vector3D(+entry , -entry , -entry);
        Vector3D posNegPosVec = new Vector3D(+entry , -entry , +entry);
        Vector3D posPosNegVec = new Vector3D(+entry , +entry , -entry);
        Vector3D posPosPosVec = new Vector3D(+entry , +entry , +entry);
        Assert.Equal(posPosPosVec , -negNegNegVec);
        Assert.Equal(posPosNegVec , -negNegPosVec);
        Assert.Equal(posNegPosVec , -negPosNegVec);
        Assert.Equal(posNegNegVec , -negPosPosVec);
        Assert.Equal(negPosPosVec , -posNegNegVec);
        Assert.Equal(negPosNegVec , -posNegPosVec);
        Assert.Equal(negNegPosVec , -posPosNegVec);
        Assert.Equal(negNegNegVec , -posPosPosVec);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(int.MaxValue)]
    public void TestVector3INegation(int entry)
    {
        Vector3I negNegNegVec = new Vector3I(-entry , -entry , -entry);
        Vector3I negNegPosVec = new Vector3I(-entry , -entry , +entry);
        Vector3I negPosNegVec = new Vector3I(-entry , +entry , -entry);
        Vector3I negPosPosVec = new Vector3I(-entry , +entry , +entry);
        Vector3I posNegNegVec = new Vector3I(+entry , -entry , -entry);
        Vector3I posNegPosVec = new Vector3I(+entry , -entry , +entry);
        Vector3I posPosNegVec = new Vector3I(+entry , +entry , -entry);
        Vector3I posPosPosVec = new Vector3I(+entry , +entry , +entry);
        Assert.Equal(posPosPosVec , -negNegNegVec);
        Assert.Equal(posPosNegVec , -negNegPosVec);
        Assert.Equal(posNegPosVec , -negPosNegVec);
        Assert.Equal(posNegNegVec , -negPosPosVec);
        Assert.Equal(negPosPosVec , -posNegNegVec);
        Assert.Equal(negPosNegVec , -posNegPosVec);
        Assert.Equal(negNegPosVec , -posPosNegVec);
        Assert.Equal(negNegNegVec , -posPosPosVec);
    }
    #endregion

    #region Test vector addition
    [Theory]
    [InlineData(-1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(+1 , +1)]
    [InlineData(-1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(+1024 , +1024)]
    public void TestVector2DAddition(double a , double b)
    {
        void TestCase(double aX , double aZ , double bX , double bZ)
        {
            Vector2D vecA     = new Vector2D(aX , aZ);
            Vector2D vecB     = new Vector2D(bX , bZ);
            Vector2D expected = new Vector2D(aX + bX , aZ + bZ);
            Assert.Equal(expected , vecA + vecB);
        }

        TestCase(0 , 0 , 0 , 0);  TestCase(0 , 0 , 0 , 0);  TestCase(a , a , a , a); TestCase(b , b , b , b);
        TestCase(0 , 0 , 0 , a);  TestCase(0 , 0 , 0 , b);  TestCase(a , a , a , b); TestCase(b , b , b , a);
        TestCase(0 , 0 , a , 0);  TestCase(0 , 0 , b , 0);  TestCase(a , a , b , a); TestCase(b , b , a , b);
        TestCase(0 , 0 , a , a);  TestCase(0 , 0 , b , b);  TestCase(a , a , b , b); TestCase(b , b , a , a);

        TestCase(0 , a , 0 , 0);  TestCase(0 , b , 0 , 0);  TestCase(a , b , a , a); TestCase(b , a , b , b);
        TestCase(0 , a , 0 , a);  TestCase(0 , b , 0 , b);  TestCase(a , b , a , b); TestCase(b , a , b , a);
        TestCase(0 , a , a , 0);  TestCase(0 , b , b , 0);  TestCase(a , b , b , a); TestCase(b , a , a , b);
        TestCase(0 , a , a , a);  TestCase(0 , b , b , b);  TestCase(a , b , b , b); TestCase(b , a , a , a);

        TestCase(a , 0 , 0 , 0);  TestCase(b , 0 , 0 , 0);  TestCase(b , a , a , a); TestCase(a , b , b , b);
        TestCase(a , 0 , 0 , a);  TestCase(b , 0 , 0 , b);  TestCase(b , a , a , b); TestCase(a , b , b , a);
        TestCase(a , 0 , a , 0);  TestCase(b , 0 , b , 0);  TestCase(b , a , b , a); TestCase(a , b , a , b);
        TestCase(a , 0 , a , a);  TestCase(b , 0 , b , b);  TestCase(b , a , b , b); TestCase(a , b , a , a);

        TestCase(a , a , 0 , 0);  TestCase(b , b , 0 , 0);  TestCase(b , b , a , a); TestCase(a , a , b , b);
        TestCase(a , a , 0 , a);  TestCase(b , b , 0 , b);  TestCase(b , b , a , b); TestCase(a , a , b , a);
        TestCase(a , a , a , 0);  TestCase(b , b , b , 0);  TestCase(b , b , b , a); TestCase(a , a , a , b);
        TestCase(a , a , a , a);  TestCase(b , b , b , b);  TestCase(b , b , b , b); TestCase(a , a , a , a);
    }

    [Theory]
    [InlineData(-1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(+1 , +1)]
    [InlineData(-1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(+1024 , +1024)]
    public void TestVector2IAddition(int a , int b)
    {
        void TestCase(int aX , int aZ , int bX , int bZ)
        {
            Vector2I vecA = new Vector2I(aX , aZ);
            Vector2I vecB = new Vector2I(bX , bZ);
            Vector2I expected = new Vector2I(aX + bX , aZ + bZ);
            Assert.Equal(expected , vecA + vecB);
        }

        TestCase(0 , 0 , 0 , 0); TestCase(0 , 0 , 0 , 0); TestCase(a , a , a , a); TestCase(b , b , b , b);
        TestCase(0 , 0 , 0 , a); TestCase(0 , 0 , 0 , b); TestCase(a , a , a , b); TestCase(b , b , b , a);
        TestCase(0 , 0 , a , 0); TestCase(0 , 0 , b , 0); TestCase(a , a , b , a); TestCase(b , b , a , b);
        TestCase(0 , 0 , a , a); TestCase(0 , 0 , b , b); TestCase(a , a , b , b); TestCase(b , b , a , a);

        TestCase(0 , a , 0 , 0); TestCase(0 , b , 0 , 0); TestCase(a , b , a , a); TestCase(b , a , b , b);
        TestCase(0 , a , 0 , a); TestCase(0 , b , 0 , b); TestCase(a , b , a , b); TestCase(b , a , b , a);
        TestCase(0 , a , a , 0); TestCase(0 , b , b , 0); TestCase(a , b , b , a); TestCase(b , a , a , b);
        TestCase(0 , a , a , a); TestCase(0 , b , b , b); TestCase(a , b , b , b); TestCase(b , a , a , a);

        TestCase(a , 0 , 0 , 0); TestCase(b , 0 , 0 , 0); TestCase(b , a , a , a); TestCase(a , b , b , b);
        TestCase(a , 0 , 0 , a); TestCase(b , 0 , 0 , b); TestCase(b , a , a , b); TestCase(a , b , b , a);
        TestCase(a , 0 , a , 0); TestCase(b , 0 , b , 0); TestCase(b , a , b , a); TestCase(a , b , a , b);
        TestCase(a , 0 , a , a); TestCase(b , 0 , b , b); TestCase(b , a , b , b); TestCase(a , b , a , a);

        TestCase(a , a , 0 , 0); TestCase(b , b , 0 , 0); TestCase(b , b , a , a); TestCase(a , a , b , b);
        TestCase(a , a , 0 , a); TestCase(b , b , 0 , b); TestCase(b , b , a , b); TestCase(a , a , b , a);
        TestCase(a , a , a , 0); TestCase(b , b , b , 0); TestCase(b , b , b , a); TestCase(a , a , a , b);
        TestCase(a , a , a , a); TestCase(b , b , b , b); TestCase(b , b , b , b); TestCase(a , a , a , a);
    }

    [Theory]
    [InlineData(-1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(+1 , +1)]
    [InlineData(-1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(+1024 , +1024)]
    public void TestVector3DAddition(double a , double b)
    {
        void TestCase(double aX , double aY , double aZ , double bX , double bY , double bZ)
        {
            Vector3D vecA = new Vector3D(aX , aY , aZ);
            Vector3D vecB = new Vector3D(bX , bY , bZ);
            Vector3D expected = new Vector3D(aX + bX , aY + bY , aZ + bZ);
            Assert.Equal(expected , vecA + vecB);
        }

        TestCase(0 , 0 , 0 , 0 , 0 , 0);  TestCase(0 , 0 , 0 , 0 , 0 , 0);  TestCase(a , a , a , a , a , a);  TestCase(b , b , b , b , b , b);
        TestCase(0 , 0 , 0 , 0 , 0 , a);  TestCase(0 , 0 , 0 , 0 , 0 , b);  TestCase(a , a , a , a , a , b);  TestCase(b , b , b , b , b , a);
        TestCase(0 , 0 , 0 , 0 , a , 0);  TestCase(0 , 0 , 0 , 0 , b , 0);  TestCase(a , a , a , a , b , a);  TestCase(b , b , b , b , a , b);
        TestCase(0 , 0 , 0 , 0 , a , a);  TestCase(0 , 0 , 0 , 0 , b , b);  TestCase(a , a , a , a , b , b);  TestCase(b , b , b , b , a , a);

        TestCase(0 , 0 , 0 , a , 0 , 0);  TestCase(0 , 0 , 0 , b , 0 , 0);  TestCase(a , a , a , b , a , a);  TestCase(b , b , b , a , b , b);
        TestCase(0 , 0 , 0 , a , 0 , a);  TestCase(0 , 0 , 0 , b , 0 , b);  TestCase(a , a , a , b , a , b);  TestCase(b , b , b , a , b , a);
        TestCase(0 , 0 , 0 , a , a , 0);  TestCase(0 , 0 , 0 , b , b , 0);  TestCase(a , a , a , b , b , a);  TestCase(b , b , b , a , a , b);
        TestCase(0 , 0 , 0 , a , a , a);  TestCase(0 , 0 , 0 , b , b , b);  TestCase(a , a , a , b , b , b);  TestCase(b , b , b , a , a , a);

        TestCase(0 , 0 , a , 0 , 0 , 0);  TestCase(0 , 0 , b , 0 , 0 , 0);  TestCase(a , a , b , a , a , a);  TestCase(b , b , a , b , b , b);
        TestCase(0 , 0 , a , 0 , 0 , a);  TestCase(0 , 0 , b , 0 , 0 , b);  TestCase(a , a , b , a , a , b);  TestCase(b , b , a , b , b , a);
        TestCase(0 , 0 , a , 0 , a , 0);  TestCase(0 , 0 , b , 0 , b , 0);  TestCase(a , a , b , a , b , a);  TestCase(b , b , a , b , a , b);
        TestCase(0 , 0 , a , 0 , a , a);  TestCase(0 , 0 , b , 0 , b , b);  TestCase(a , a , b , a , b , b);  TestCase(b , b , a , b , a , a);

        TestCase(0 , 0 , a , a , 0 , 0);  TestCase(0 , 0 , b , b , 0 , 0);  TestCase(a , a , b , b , a , a);  TestCase(b , b , a , a , b , b);
        TestCase(0 , 0 , a , a , 0 , a);  TestCase(0 , 0 , b , b , 0 , b);  TestCase(a , a , b , b , a , b);  TestCase(b , b , a , a , b , a);
        TestCase(0 , 0 , a , a , a , 0);  TestCase(0 , 0 , b , b , b , 0);  TestCase(a , a , b , b , b , a);  TestCase(b , b , a , a , a , b);
        TestCase(0 , 0 , a , a , a , a);  TestCase(0 , 0 , b , b , b , b);  TestCase(a , a , b , b , b , b);  TestCase(b , b , a , a , a , a);

        TestCase(0 , a , 0 , 0 , 0 , 0);  TestCase(0 , b , 0 , 0 , 0 , 0);  TestCase(a , b , a , a , a , a);  TestCase(b , a , b , b , b , b);
        TestCase(0 , a , 0 , 0 , 0 , a);  TestCase(0 , b , 0 , 0 , 0 , b);  TestCase(a , b , a , a , a , b);  TestCase(b , a , b , b , b , a);
        TestCase(0 , a , 0 , 0 , a , 0);  TestCase(0 , b , 0 , 0 , b , 0);  TestCase(a , b , a , a , b , a);  TestCase(b , a , b , b , a , b);
        TestCase(0 , a , 0 , 0 , a , a);  TestCase(0 , b , 0 , 0 , b , b);  TestCase(a , b , a , a , b , b);  TestCase(b , a , b , b , a , a);

        TestCase(0 , a , 0 , a , 0 , 0);  TestCase(0 , b , 0 , b , 0 , 0);  TestCase(a , b , a , b , a , a);  TestCase(b , a , b , a , b , b);
        TestCase(0 , a , 0 , a , 0 , a);  TestCase(0 , b , 0 , b , 0 , b);  TestCase(a , b , a , b , a , b);  TestCase(b , a , b , a , b , a);
        TestCase(0 , a , 0 , a , a , 0);  TestCase(0 , b , 0 , b , b , 0);  TestCase(a , b , a , b , b , a);  TestCase(b , a , b , a , a , b);
        TestCase(0 , a , 0 , a , a , a);  TestCase(0 , b , 0 , b , b , b);  TestCase(a , b , a , b , b , b);  TestCase(b , a , b , a , a , a);

        TestCase(0 , a , a , 0 , 0 , 0);  TestCase(0 , b , b , 0 , 0 , 0);  TestCase(a , b , b , a , a , a);  TestCase(b , a , a , b , b , b);
        TestCase(0 , a , a , 0 , 0 , a);  TestCase(0 , b , b , 0 , 0 , b);  TestCase(a , b , b , a , a , b);  TestCase(b , a , a , b , b , a);
        TestCase(0 , a , a , 0 , a , 0);  TestCase(0 , b , b , 0 , b , 0);  TestCase(a , b , b , a , b , a);  TestCase(b , a , a , b , a , b);
        TestCase(0 , a , a , 0 , a , a);  TestCase(0 , b , b , 0 , b , b);  TestCase(a , b , b , a , b , b);  TestCase(b , a , a , b , a , a);

        TestCase(0 , a , a , a , 0 , 0);  TestCase(0 , b , b , b , 0 , 0);  TestCase(a , b , b , b , a , a);  TestCase(b , a , a , a , b , b);
        TestCase(0 , a , a , a , 0 , a);  TestCase(0 , b , b , b , 0 , b);  TestCase(a , b , b , b , a , b);  TestCase(b , a , a , a , b , a);
        TestCase(0 , a , a , a , a , 0);  TestCase(0 , b , b , b , b , 0);  TestCase(a , b , b , b , b , a);  TestCase(b , a , a , a , a , b);
        TestCase(0 , a , a , a , a , a);  TestCase(0 , b , b , b , b , b);  TestCase(a , b , b , b , b , b);  TestCase(b , a , a , a , a , a);

        TestCase(a , 0 , 0 , 0 , 0 , 0);  TestCase(b , 0 , 0 , 0 , 0 , 0);  TestCase(b , a , a , a , a , a);  TestCase(a , b , b , b , b , b);
        TestCase(a , 0 , 0 , 0 , 0 , a);  TestCase(b , 0 , 0 , 0 , 0 , b);  TestCase(b , a , a , a , a , b);  TestCase(a , b , b , b , b , a);
        TestCase(a , 0 , 0 , 0 , a , 0);  TestCase(b , 0 , 0 , 0 , b , 0);  TestCase(b , a , a , a , b , a);  TestCase(a , b , b , b , a , b);
        TestCase(a , 0 , 0 , 0 , a , a);  TestCase(b , 0 , 0 , 0 , b , b);  TestCase(b , a , a , a , b , b);  TestCase(a , b , b , b , a , a);

        TestCase(a , 0 , 0 , a , 0 , 0);  TestCase(b , 0 , 0 , b , 0 , 0);  TestCase(b , a , a , b , a , a);  TestCase(a , b , b , a , b , b);
        TestCase(a , 0 , 0 , a , 0 , a);  TestCase(b , 0 , 0 , b , 0 , b);  TestCase(b , a , a , b , a , b);  TestCase(a , b , b , a , b , a);
        TestCase(a , 0 , 0 , a , a , 0);  TestCase(b , 0 , 0 , b , b , 0);  TestCase(b , a , a , b , b , a);  TestCase(a , b , b , a , a , b);
        TestCase(a , 0 , 0 , a , a , a);  TestCase(b , 0 , 0 , b , b , b);  TestCase(b , a , a , b , b , b);  TestCase(a , b , b , a , a , a);

        TestCase(a , 0 , a , 0 , 0 , 0);  TestCase(b , 0 , b , 0 , 0 , 0);  TestCase(b , a , b , a , a , a);  TestCase(a , b , a , b , b , b);
        TestCase(a , 0 , a , 0 , 0 , a);  TestCase(b , 0 , b , 0 , 0 , b);  TestCase(b , a , b , a , a , b);  TestCase(a , b , a , b , b , a);
        TestCase(a , 0 , a , 0 , a , 0);  TestCase(b , 0 , b , 0 , b , 0);  TestCase(b , a , b , a , b , a);  TestCase(a , b , a , b , a , b);
        TestCase(a , 0 , a , 0 , a , a);  TestCase(b , 0 , b , 0 , b , b);  TestCase(b , a , b , a , b , b);  TestCase(a , b , a , b , a , a);

        TestCase(a , 0 , a , a , 0 , 0);  TestCase(b , 0 , b , b , 0 , 0);  TestCase(b , a , b , b , a , a);  TestCase(a , b , a , a , b , b);
        TestCase(a , 0 , a , a , 0 , a);  TestCase(b , 0 , b , b , 0 , b);  TestCase(b , a , b , b , a , b);  TestCase(a , b , a , a , b , a);
        TestCase(a , 0 , a , a , a , 0);  TestCase(b , 0 , b , b , b , 0);  TestCase(b , a , b , b , b , a);  TestCase(a , b , a , a , a , b);
        TestCase(a , 0 , a , a , a , a);  TestCase(b , 0 , b , b , b , b);  TestCase(b , a , b , b , b , b);  TestCase(a , b , a , a , a , a);

        TestCase(a , a , 0 , 0 , 0 , 0);  TestCase(b , b , 0 , 0 , 0 , 0);  TestCase(b , b , a , a , a , a);  TestCase(a , a , b , b , b , b);
        TestCase(a , a , 0 , 0 , 0 , a);  TestCase(b , b , 0 , 0 , 0 , b);  TestCase(b , b , a , a , a , b);  TestCase(a , a , b , b , b , a);
        TestCase(a , a , 0 , 0 , a , 0);  TestCase(b , b , 0 , 0 , b , 0);  TestCase(b , b , a , a , b , a);  TestCase(a , a , b , b , a , b);
        TestCase(a , a , 0 , 0 , a , a);  TestCase(b , b , 0 , 0 , b , b);  TestCase(b , b , a , a , b , b);  TestCase(a , a , b , b , a , a);

        TestCase(a , a , 0 , a , 0 , 0);  TestCase(b , b , 0 , b , 0 , 0);  TestCase(b , b , a , b , a , a);  TestCase(a , a , b , a , b , b);
        TestCase(a , a , 0 , a , 0 , a);  TestCase(b , b , 0 , b , 0 , b);  TestCase(b , b , a , b , a , b);  TestCase(a , a , b , a , b , a);
        TestCase(a , a , 0 , a , a , 0);  TestCase(b , b , 0 , b , b , 0);  TestCase(b , b , a , b , b , a);  TestCase(a , a , b , a , a , b);
        TestCase(a , a , 0 , a , a , a);  TestCase(b , b , 0 , b , b , b);  TestCase(b , b , a , b , b , b);  TestCase(a , a , b , a , a , a);

        TestCase(a , a , a , 0 , 0 , 0);  TestCase(b , b , b , 0 , 0 , 0);  TestCase(b , b , b , a , a , a);  TestCase(a , a , a , b , b , b);
        TestCase(a , a , a , 0 , 0 , a);  TestCase(b , b , b , 0 , 0 , b);  TestCase(b , b , b , a , a , b);  TestCase(a , a , a , b , b , a);
        TestCase(a , a , a , 0 , a , 0);  TestCase(b , b , b , 0 , b , 0);  TestCase(b , b , b , a , b , a);  TestCase(a , a , a , b , a , b);
        TestCase(a , a , a , 0 , a , a);  TestCase(b , b , b , 0 , b , b);  TestCase(b , b , b , a , b , b);  TestCase(a , a , a , b , a , a);

        TestCase(a , a , a , a , 0 , 0);  TestCase(b , b , b , b , 0 , 0);  TestCase(b , b , b , b , a , a);  TestCase(a , a , a , a , b , b);
        TestCase(a , a , a , a , 0 , a);  TestCase(b , b , b , b , 0 , b);  TestCase(b , b , b , b , a , b);  TestCase(a , a , a , a , b , a);
        TestCase(a , a , a , a , a , 0);  TestCase(b , b , b , b , b , 0);  TestCase(b , b , b , b , b , a);  TestCase(a , a , a , a , a , b);
        TestCase(a , a , a , a , a , a);  TestCase(b , b , b , b , b , b);  TestCase(b , b , b , b , b , b);  TestCase(a , a , a , a , a , a);
    }

    [Theory]
    [InlineData(-1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(+1 , +1)]
    [InlineData(-1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(+1024 , +1024)]
    public void TestVector3IAddition(int a , int b)
    {
        void TestCase(int aX , int aY , int aZ , int bX , int bY , int bZ)
        {
            Vector3I vecA = new Vector3I(aX , aY , aZ);
            Vector3I vecB = new Vector3I(bX , bY , bZ);
            Vector3I expected = new Vector3I(aX + bX , aY + bY , aZ + bZ);
            Assert.Equal(expected , vecA + vecB);
        }

        TestCase(0 , 0 , 0 , 0 , 0 , 0);  TestCase(0 , 0 , 0 , 0 , 0 , 0);  TestCase(a , a , a , a , a , a);  TestCase(b , b , b , b , b , b);
        TestCase(0 , 0 , 0 , 0 , 0 , a);  TestCase(0 , 0 , 0 , 0 , 0 , b);  TestCase(a , a , a , a , a , b);  TestCase(b , b , b , b , b , a);
        TestCase(0 , 0 , 0 , 0 , a , 0);  TestCase(0 , 0 , 0 , 0 , b , 0);  TestCase(a , a , a , a , b , a);  TestCase(b , b , b , b , a , b);
        TestCase(0 , 0 , 0 , 0 , a , a);  TestCase(0 , 0 , 0 , 0 , b , b);  TestCase(a , a , a , a , b , b);  TestCase(b , b , b , b , a , a);

        TestCase(0 , 0 , 0 , a , 0 , 0);  TestCase(0 , 0 , 0 , b , 0 , 0);  TestCase(a , a , a , b , a , a);  TestCase(b , b , b , a , b , b);
        TestCase(0 , 0 , 0 , a , 0 , a);  TestCase(0 , 0 , 0 , b , 0 , b);  TestCase(a , a , a , b , a , b);  TestCase(b , b , b , a , b , a);
        TestCase(0 , 0 , 0 , a , a , 0);  TestCase(0 , 0 , 0 , b , b , 0);  TestCase(a , a , a , b , b , a);  TestCase(b , b , b , a , a , b);
        TestCase(0 , 0 , 0 , a , a , a);  TestCase(0 , 0 , 0 , b , b , b);  TestCase(a , a , a , b , b , b);  TestCase(b , b , b , a , a , a);

        TestCase(0 , 0 , a , 0 , 0 , 0);  TestCase(0 , 0 , b , 0 , 0 , 0);  TestCase(a , a , b , a , a , a);  TestCase(b , b , a , b , b , b);
        TestCase(0 , 0 , a , 0 , 0 , a);  TestCase(0 , 0 , b , 0 , 0 , b);  TestCase(a , a , b , a , a , b);  TestCase(b , b , a , b , b , a);
        TestCase(0 , 0 , a , 0 , a , 0);  TestCase(0 , 0 , b , 0 , b , 0);  TestCase(a , a , b , a , b , a);  TestCase(b , b , a , b , a , b);
        TestCase(0 , 0 , a , 0 , a , a);  TestCase(0 , 0 , b , 0 , b , b);  TestCase(a , a , b , a , b , b);  TestCase(b , b , a , b , a , a);

        TestCase(0 , 0 , a , a , 0 , 0);  TestCase(0 , 0 , b , b , 0 , 0);  TestCase(a , a , b , b , a , a);  TestCase(b , b , a , a , b , b);
        TestCase(0 , 0 , a , a , 0 , a);  TestCase(0 , 0 , b , b , 0 , b);  TestCase(a , a , b , b , a , b);  TestCase(b , b , a , a , b , a);
        TestCase(0 , 0 , a , a , a , 0);  TestCase(0 , 0 , b , b , b , 0);  TestCase(a , a , b , b , b , a);  TestCase(b , b , a , a , a , b);
        TestCase(0 , 0 , a , a , a , a);  TestCase(0 , 0 , b , b , b , b);  TestCase(a , a , b , b , b , b);  TestCase(b , b , a , a , a , a);

        TestCase(0 , a , 0 , 0 , 0 , 0);  TestCase(0 , b , 0 , 0 , 0 , 0);  TestCase(a , b , a , a , a , a);  TestCase(b , a , b , b , b , b);
        TestCase(0 , a , 0 , 0 , 0 , a);  TestCase(0 , b , 0 , 0 , 0 , b);  TestCase(a , b , a , a , a , b);  TestCase(b , a , b , b , b , a);
        TestCase(0 , a , 0 , 0 , a , 0);  TestCase(0 , b , 0 , 0 , b , 0);  TestCase(a , b , a , a , b , a);  TestCase(b , a , b , b , a , b);
        TestCase(0 , a , 0 , 0 , a , a);  TestCase(0 , b , 0 , 0 , b , b);  TestCase(a , b , a , a , b , b);  TestCase(b , a , b , b , a , a);

        TestCase(0 , a , 0 , a , 0 , 0);  TestCase(0 , b , 0 , b , 0 , 0);  TestCase(a , b , a , b , a , a);  TestCase(b , a , b , a , b , b);
        TestCase(0 , a , 0 , a , 0 , a);  TestCase(0 , b , 0 , b , 0 , b);  TestCase(a , b , a , b , a , b);  TestCase(b , a , b , a , b , a);
        TestCase(0 , a , 0 , a , a , 0);  TestCase(0 , b , 0 , b , b , 0);  TestCase(a , b , a , b , b , a);  TestCase(b , a , b , a , a , b);
        TestCase(0 , a , 0 , a , a , a);  TestCase(0 , b , 0 , b , b , b);  TestCase(a , b , a , b , b , b);  TestCase(b , a , b , a , a , a);

        TestCase(0 , a , a , 0 , 0 , 0);  TestCase(0 , b , b , 0 , 0 , 0);  TestCase(a , b , b , a , a , a);  TestCase(b , a , a , b , b , b);
        TestCase(0 , a , a , 0 , 0 , a);  TestCase(0 , b , b , 0 , 0 , b);  TestCase(a , b , b , a , a , b);  TestCase(b , a , a , b , b , a);
        TestCase(0 , a , a , 0 , a , 0);  TestCase(0 , b , b , 0 , b , 0);  TestCase(a , b , b , a , b , a);  TestCase(b , a , a , b , a , b);
        TestCase(0 , a , a , 0 , a , a);  TestCase(0 , b , b , 0 , b , b);  TestCase(a , b , b , a , b , b);  TestCase(b , a , a , b , a , a);

        TestCase(0 , a , a , a , 0 , 0);  TestCase(0 , b , b , b , 0 , 0);  TestCase(a , b , b , b , a , a);  TestCase(b , a , a , a , b , b);
        TestCase(0 , a , a , a , 0 , a);  TestCase(0 , b , b , b , 0 , b);  TestCase(a , b , b , b , a , b);  TestCase(b , a , a , a , b , a);
        TestCase(0 , a , a , a , a , 0);  TestCase(0 , b , b , b , b , 0);  TestCase(a , b , b , b , b , a);  TestCase(b , a , a , a , a , b);
        TestCase(0 , a , a , a , a , a);  TestCase(0 , b , b , b , b , b);  TestCase(a , b , b , b , b , b);  TestCase(b , a , a , a , a , a);

        TestCase(a , 0 , 0 , 0 , 0 , 0);  TestCase(b , 0 , 0 , 0 , 0 , 0);  TestCase(b , a , a , a , a , a);  TestCase(a , b , b , b , b , b);
        TestCase(a , 0 , 0 , 0 , 0 , a);  TestCase(b , 0 , 0 , 0 , 0 , b);  TestCase(b , a , a , a , a , b);  TestCase(a , b , b , b , b , a);
        TestCase(a , 0 , 0 , 0 , a , 0);  TestCase(b , 0 , 0 , 0 , b , 0);  TestCase(b , a , a , a , b , a);  TestCase(a , b , b , b , a , b);
        TestCase(a , 0 , 0 , 0 , a , a);  TestCase(b , 0 , 0 , 0 , b , b);  TestCase(b , a , a , a , b , b);  TestCase(a , b , b , b , a , a);

        TestCase(a , 0 , 0 , a , 0 , 0);  TestCase(b , 0 , 0 , b , 0 , 0);  TestCase(b , a , a , b , a , a);  TestCase(a , b , b , a , b , b);
        TestCase(a , 0 , 0 , a , 0 , a);  TestCase(b , 0 , 0 , b , 0 , b);  TestCase(b , a , a , b , a , b);  TestCase(a , b , b , a , b , a);
        TestCase(a , 0 , 0 , a , a , 0);  TestCase(b , 0 , 0 , b , b , 0);  TestCase(b , a , a , b , b , a);  TestCase(a , b , b , a , a , b);
        TestCase(a , 0 , 0 , a , a , a);  TestCase(b , 0 , 0 , b , b , b);  TestCase(b , a , a , b , b , b);  TestCase(a , b , b , a , a , a);

        TestCase(a , 0 , a , 0 , 0 , 0);  TestCase(b , 0 , b , 0 , 0 , 0);  TestCase(b , a , b , a , a , a);  TestCase(a , b , a , b , b , b);
        TestCase(a , 0 , a , 0 , 0 , a);  TestCase(b , 0 , b , 0 , 0 , b);  TestCase(b , a , b , a , a , b);  TestCase(a , b , a , b , b , a);
        TestCase(a , 0 , a , 0 , a , 0);  TestCase(b , 0 , b , 0 , b , 0);  TestCase(b , a , b , a , b , a);  TestCase(a , b , a , b , a , b);
        TestCase(a , 0 , a , 0 , a , a);  TestCase(b , 0 , b , 0 , b , b);  TestCase(b , a , b , a , b , b);  TestCase(a , b , a , b , a , a);

        TestCase(a , 0 , a , a , 0 , 0);  TestCase(b , 0 , b , b , 0 , 0);  TestCase(b , a , b , b , a , a);  TestCase(a , b , a , a , b , b);
        TestCase(a , 0 , a , a , 0 , a);  TestCase(b , 0 , b , b , 0 , b);  TestCase(b , a , b , b , a , b);  TestCase(a , b , a , a , b , a);
        TestCase(a , 0 , a , a , a , 0);  TestCase(b , 0 , b , b , b , 0);  TestCase(b , a , b , b , b , a);  TestCase(a , b , a , a , a , b);
        TestCase(a , 0 , a , a , a , a);  TestCase(b , 0 , b , b , b , b);  TestCase(b , a , b , b , b , b);  TestCase(a , b , a , a , a , a);

        TestCase(a , a , 0 , 0 , 0 , 0);  TestCase(b , b , 0 , 0 , 0 , 0);  TestCase(b , b , a , a , a , a);  TestCase(a , a , b , b , b , b);
        TestCase(a , a , 0 , 0 , 0 , a);  TestCase(b , b , 0 , 0 , 0 , b);  TestCase(b , b , a , a , a , b);  TestCase(a , a , b , b , b , a);
        TestCase(a , a , 0 , 0 , a , 0);  TestCase(b , b , 0 , 0 , b , 0);  TestCase(b , b , a , a , b , a);  TestCase(a , a , b , b , a , b);
        TestCase(a , a , 0 , 0 , a , a);  TestCase(b , b , 0 , 0 , b , b);  TestCase(b , b , a , a , b , b);  TestCase(a , a , b , b , a , a);

        TestCase(a , a , 0 , a , 0 , 0);  TestCase(b , b , 0 , b , 0 , 0);  TestCase(b , b , a , b , a , a);  TestCase(a , a , b , a , b , b);
        TestCase(a , a , 0 , a , 0 , a);  TestCase(b , b , 0 , b , 0 , b);  TestCase(b , b , a , b , a , b);  TestCase(a , a , b , a , b , a);
        TestCase(a , a , 0 , a , a , 0);  TestCase(b , b , 0 , b , b , 0);  TestCase(b , b , a , b , b , a);  TestCase(a , a , b , a , a , b);
        TestCase(a , a , 0 , a , a , a);  TestCase(b , b , 0 , b , b , b);  TestCase(b , b , a , b , b , b);  TestCase(a , a , b , a , a , a);

        TestCase(a , a , a , 0 , 0 , 0);  TestCase(b , b , b , 0 , 0 , 0);  TestCase(b , b , b , a , a , a);  TestCase(a , a , a , b , b , b);
        TestCase(a , a , a , 0 , 0 , a);  TestCase(b , b , b , 0 , 0 , b);  TestCase(b , b , b , a , a , b);  TestCase(a , a , a , b , b , a);
        TestCase(a , a , a , 0 , a , 0);  TestCase(b , b , b , 0 , b , 0);  TestCase(b , b , b , a , b , a);  TestCase(a , a , a , b , a , b);
        TestCase(a , a , a , 0 , a , a);  TestCase(b , b , b , 0 , b , b);  TestCase(b , b , b , a , b , b);  TestCase(a , a , a , b , a , a);

        TestCase(a , a , a , a , 0 , 0);  TestCase(b , b , b , b , 0 , 0);  TestCase(b , b , b , b , a , a);  TestCase(a , a , a , a , b , b);
        TestCase(a , a , a , a , 0 , a);  TestCase(b , b , b , b , 0 , b);  TestCase(b , b , b , b , a , b);  TestCase(a , a , a , a , b , a);
        TestCase(a , a , a , a , a , 0);  TestCase(b , b , b , b , b , 0);  TestCase(b , b , b , b , b , a);  TestCase(a , a , a , a , a , b);
        TestCase(a , a , a , a , a , a);  TestCase(b , b , b , b , b , b);  TestCase(b , b , b , b , b , b);  TestCase(a , a , a , a , a , a);
    }
    #endregion

    #region Test vector subtraction
    [Theory]
    [InlineData(-1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(+1 , +1)]
    [InlineData(-1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(+1024 , +1024)]
    public void TestVector2DSubtraction(double a , double b)
    {
        void TestCase(double aX , double aZ , double bX , double bZ)
        {
            Vector2D vecA     = new Vector2D(aX , aZ);
            Vector2D vecB     = new Vector2D(bX , bZ);
            Vector2D expected = new Vector2D(aX - bX , aZ - bZ);
            Assert.Equal(expected , vecA - vecB);
        }

        TestCase(0 , 0 , 0 , 0);  TestCase(0 , 0 , 0 , 0);  TestCase(a , a , a , a); TestCase(b , b , b , b);
        TestCase(0 , 0 , 0 , a);  TestCase(0 , 0 , 0 , b);  TestCase(a , a , a , b); TestCase(b , b , b , a);
        TestCase(0 , 0 , a , 0);  TestCase(0 , 0 , b , 0);  TestCase(a , a , b , a); TestCase(b , b , a , b);
        TestCase(0 , 0 , a , a);  TestCase(0 , 0 , b , b);  TestCase(a , a , b , b); TestCase(b , b , a , a);

        TestCase(0 , a , 0 , 0);  TestCase(0 , b , 0 , 0);  TestCase(a , b , a , a); TestCase(b , a , b , b);
        TestCase(0 , a , 0 , a);  TestCase(0 , b , 0 , b);  TestCase(a , b , a , b); TestCase(b , a , b , a);
        TestCase(0 , a , a , 0);  TestCase(0 , b , b , 0);  TestCase(a , b , b , a); TestCase(b , a , a , b);
        TestCase(0 , a , a , a);  TestCase(0 , b , b , b);  TestCase(a , b , b , b); TestCase(b , a , a , a);

        TestCase(a , 0 , 0 , 0);  TestCase(b , 0 , 0 , 0);  TestCase(b , a , a , a); TestCase(a , b , b , b);
        TestCase(a , 0 , 0 , a);  TestCase(b , 0 , 0 , b);  TestCase(b , a , a , b); TestCase(a , b , b , a);
        TestCase(a , 0 , a , 0);  TestCase(b , 0 , b , 0);  TestCase(b , a , b , a); TestCase(a , b , a , b);
        TestCase(a , 0 , a , a);  TestCase(b , 0 , b , b);  TestCase(b , a , b , b); TestCase(a , b , a , a);

        TestCase(a , a , 0 , 0);  TestCase(b , b , 0 , 0);  TestCase(b , b , a , a); TestCase(a , a , b , b);
        TestCase(a , a , 0 , a);  TestCase(b , b , 0 , b);  TestCase(b , b , a , b); TestCase(a , a , b , a);
        TestCase(a , a , a , 0);  TestCase(b , b , b , 0);  TestCase(b , b , b , a); TestCase(a , a , a , b);
        TestCase(a , a , a , a);  TestCase(b , b , b , b);  TestCase(b , b , b , b); TestCase(a , a , a , a);
    }

    [Theory]
    [InlineData(-1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(+1 , +1)]
    [InlineData(-1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(+1024 , +1024)]
    public void TestVector2ISubtraction(int a , int b)
    {
        void TestCase(int aX , int aZ , int bX , int bZ)
        {
            Vector2I vecA = new Vector2I(aX , aZ);
            Vector2I vecB = new Vector2I(bX , bZ);
            Vector2I expected = new Vector2I(aX - bX , aZ - bZ);
            Assert.Equal(expected , vecA - vecB);
        }

        TestCase(0 , 0 , 0 , 0); TestCase(0 , 0 , 0 , 0); TestCase(a , a , a , a); TestCase(b , b , b , b);
        TestCase(0 , 0 , 0 , a); TestCase(0 , 0 , 0 , b); TestCase(a , a , a , b); TestCase(b , b , b , a);
        TestCase(0 , 0 , a , 0); TestCase(0 , 0 , b , 0); TestCase(a , a , b , a); TestCase(b , b , a , b);
        TestCase(0 , 0 , a , a); TestCase(0 , 0 , b , b); TestCase(a , a , b , b); TestCase(b , b , a , a);

        TestCase(0 , a , 0 , 0); TestCase(0 , b , 0 , 0); TestCase(a , b , a , a); TestCase(b , a , b , b);
        TestCase(0 , a , 0 , a); TestCase(0 , b , 0 , b); TestCase(a , b , a , b); TestCase(b , a , b , a);
        TestCase(0 , a , a , 0); TestCase(0 , b , b , 0); TestCase(a , b , b , a); TestCase(b , a , a , b);
        TestCase(0 , a , a , a); TestCase(0 , b , b , b); TestCase(a , b , b , b); TestCase(b , a , a , a);

        TestCase(a , 0 , 0 , 0); TestCase(b , 0 , 0 , 0); TestCase(b , a , a , a); TestCase(a , b , b , b);
        TestCase(a , 0 , 0 , a); TestCase(b , 0 , 0 , b); TestCase(b , a , a , b); TestCase(a , b , b , a);
        TestCase(a , 0 , a , 0); TestCase(b , 0 , b , 0); TestCase(b , a , b , a); TestCase(a , b , a , b);
        TestCase(a , 0 , a , a); TestCase(b , 0 , b , b); TestCase(b , a , b , b); TestCase(a , b , a , a);

        TestCase(a , a , 0 , 0); TestCase(b , b , 0 , 0); TestCase(b , b , a , a); TestCase(a , a , b , b);
        TestCase(a , a , 0 , a); TestCase(b , b , 0 , b); TestCase(b , b , a , b); TestCase(a , a , b , a);
        TestCase(a , a , a , 0); TestCase(b , b , b , 0); TestCase(b , b , b , a); TestCase(a , a , a , b);
        TestCase(a , a , a , a); TestCase(b , b , b , b); TestCase(b , b , b , b); TestCase(a , a , a , a);
    }

    [Theory]
    [InlineData(-1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(+1 , +1)]
    [InlineData(-1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(+1024 , +1024)]
    public void TestVector3DSubtraction(double a , double b)
    {
        void TestCase(double aX , double aY , double aZ , double bX , double bY , double bZ)
        {
            Vector3D vecA = new Vector3D(aX , aY , aZ);
            Vector3D vecB = new Vector3D(bX , bY , bZ);
            Vector3D expected = new Vector3D(aX - bX , aY - bY , aZ - bZ);
            Assert.Equal(expected , vecA - vecB);
        }

        TestCase(0 , 0 , 0 , 0 , 0 , 0);  TestCase(0 , 0 , 0 , 0 , 0 , 0);  TestCase(a , a , a , a , a , a);  TestCase(b , b , b , b , b , b);
        TestCase(0 , 0 , 0 , 0 , 0 , a);  TestCase(0 , 0 , 0 , 0 , 0 , b);  TestCase(a , a , a , a , a , b);  TestCase(b , b , b , b , b , a);
        TestCase(0 , 0 , 0 , 0 , a , 0);  TestCase(0 , 0 , 0 , 0 , b , 0);  TestCase(a , a , a , a , b , a);  TestCase(b , b , b , b , a , b);
        TestCase(0 , 0 , 0 , 0 , a , a);  TestCase(0 , 0 , 0 , 0 , b , b);  TestCase(a , a , a , a , b , b);  TestCase(b , b , b , b , a , a);

        TestCase(0 , 0 , 0 , a , 0 , 0);  TestCase(0 , 0 , 0 , b , 0 , 0);  TestCase(a , a , a , b , a , a);  TestCase(b , b , b , a , b , b);
        TestCase(0 , 0 , 0 , a , 0 , a);  TestCase(0 , 0 , 0 , b , 0 , b);  TestCase(a , a , a , b , a , b);  TestCase(b , b , b , a , b , a);
        TestCase(0 , 0 , 0 , a , a , 0);  TestCase(0 , 0 , 0 , b , b , 0);  TestCase(a , a , a , b , b , a);  TestCase(b , b , b , a , a , b);
        TestCase(0 , 0 , 0 , a , a , a);  TestCase(0 , 0 , 0 , b , b , b);  TestCase(a , a , a , b , b , b);  TestCase(b , b , b , a , a , a);

        TestCase(0 , 0 , a , 0 , 0 , 0);  TestCase(0 , 0 , b , 0 , 0 , 0);  TestCase(a , a , b , a , a , a);  TestCase(b , b , a , b , b , b);
        TestCase(0 , 0 , a , 0 , 0 , a);  TestCase(0 , 0 , b , 0 , 0 , b);  TestCase(a , a , b , a , a , b);  TestCase(b , b , a , b , b , a);
        TestCase(0 , 0 , a , 0 , a , 0);  TestCase(0 , 0 , b , 0 , b , 0);  TestCase(a , a , b , a , b , a);  TestCase(b , b , a , b , a , b);
        TestCase(0 , 0 , a , 0 , a , a);  TestCase(0 , 0 , b , 0 , b , b);  TestCase(a , a , b , a , b , b);  TestCase(b , b , a , b , a , a);

        TestCase(0 , 0 , a , a , 0 , 0);  TestCase(0 , 0 , b , b , 0 , 0);  TestCase(a , a , b , b , a , a);  TestCase(b , b , a , a , b , b);
        TestCase(0 , 0 , a , a , 0 , a);  TestCase(0 , 0 , b , b , 0 , b);  TestCase(a , a , b , b , a , b);  TestCase(b , b , a , a , b , a);
        TestCase(0 , 0 , a , a , a , 0);  TestCase(0 , 0 , b , b , b , 0);  TestCase(a , a , b , b , b , a);  TestCase(b , b , a , a , a , b);
        TestCase(0 , 0 , a , a , a , a);  TestCase(0 , 0 , b , b , b , b);  TestCase(a , a , b , b , b , b);  TestCase(b , b , a , a , a , a);

        TestCase(0 , a , 0 , 0 , 0 , 0);  TestCase(0 , b , 0 , 0 , 0 , 0);  TestCase(a , b , a , a , a , a);  TestCase(b , a , b , b , b , b);
        TestCase(0 , a , 0 , 0 , 0 , a);  TestCase(0 , b , 0 , 0 , 0 , b);  TestCase(a , b , a , a , a , b);  TestCase(b , a , b , b , b , a);
        TestCase(0 , a , 0 , 0 , a , 0);  TestCase(0 , b , 0 , 0 , b , 0);  TestCase(a , b , a , a , b , a);  TestCase(b , a , b , b , a , b);
        TestCase(0 , a , 0 , 0 , a , a);  TestCase(0 , b , 0 , 0 , b , b);  TestCase(a , b , a , a , b , b);  TestCase(b , a , b , b , a , a);

        TestCase(0 , a , 0 , a , 0 , 0);  TestCase(0 , b , 0 , b , 0 , 0);  TestCase(a , b , a , b , a , a);  TestCase(b , a , b , a , b , b);
        TestCase(0 , a , 0 , a , 0 , a);  TestCase(0 , b , 0 , b , 0 , b);  TestCase(a , b , a , b , a , b);  TestCase(b , a , b , a , b , a);
        TestCase(0 , a , 0 , a , a , 0);  TestCase(0 , b , 0 , b , b , 0);  TestCase(a , b , a , b , b , a);  TestCase(b , a , b , a , a , b);
        TestCase(0 , a , 0 , a , a , a);  TestCase(0 , b , 0 , b , b , b);  TestCase(a , b , a , b , b , b);  TestCase(b , a , b , a , a , a);

        TestCase(0 , a , a , 0 , 0 , 0);  TestCase(0 , b , b , 0 , 0 , 0);  TestCase(a , b , b , a , a , a);  TestCase(b , a , a , b , b , b);
        TestCase(0 , a , a , 0 , 0 , a);  TestCase(0 , b , b , 0 , 0 , b);  TestCase(a , b , b , a , a , b);  TestCase(b , a , a , b , b , a);
        TestCase(0 , a , a , 0 , a , 0);  TestCase(0 , b , b , 0 , b , 0);  TestCase(a , b , b , a , b , a);  TestCase(b , a , a , b , a , b);
        TestCase(0 , a , a , 0 , a , a);  TestCase(0 , b , b , 0 , b , b);  TestCase(a , b , b , a , b , b);  TestCase(b , a , a , b , a , a);

        TestCase(0 , a , a , a , 0 , 0);  TestCase(0 , b , b , b , 0 , 0);  TestCase(a , b , b , b , a , a);  TestCase(b , a , a , a , b , b);
        TestCase(0 , a , a , a , 0 , a);  TestCase(0 , b , b , b , 0 , b);  TestCase(a , b , b , b , a , b);  TestCase(b , a , a , a , b , a);
        TestCase(0 , a , a , a , a , 0);  TestCase(0 , b , b , b , b , 0);  TestCase(a , b , b , b , b , a);  TestCase(b , a , a , a , a , b);
        TestCase(0 , a , a , a , a , a);  TestCase(0 , b , b , b , b , b);  TestCase(a , b , b , b , b , b);  TestCase(b , a , a , a , a , a);

        TestCase(a , 0 , 0 , 0 , 0 , 0);  TestCase(b , 0 , 0 , 0 , 0 , 0);  TestCase(b , a , a , a , a , a);  TestCase(a , b , b , b , b , b);
        TestCase(a , 0 , 0 , 0 , 0 , a);  TestCase(b , 0 , 0 , 0 , 0 , b);  TestCase(b , a , a , a , a , b);  TestCase(a , b , b , b , b , a);
        TestCase(a , 0 , 0 , 0 , a , 0);  TestCase(b , 0 , 0 , 0 , b , 0);  TestCase(b , a , a , a , b , a);  TestCase(a , b , b , b , a , b);
        TestCase(a , 0 , 0 , 0 , a , a);  TestCase(b , 0 , 0 , 0 , b , b);  TestCase(b , a , a , a , b , b);  TestCase(a , b , b , b , a , a);

        TestCase(a , 0 , 0 , a , 0 , 0);  TestCase(b , 0 , 0 , b , 0 , 0);  TestCase(b , a , a , b , a , a);  TestCase(a , b , b , a , b , b);
        TestCase(a , 0 , 0 , a , 0 , a);  TestCase(b , 0 , 0 , b , 0 , b);  TestCase(b , a , a , b , a , b);  TestCase(a , b , b , a , b , a);
        TestCase(a , 0 , 0 , a , a , 0);  TestCase(b , 0 , 0 , b , b , 0);  TestCase(b , a , a , b , b , a);  TestCase(a , b , b , a , a , b);
        TestCase(a , 0 , 0 , a , a , a);  TestCase(b , 0 , 0 , b , b , b);  TestCase(b , a , a , b , b , b);  TestCase(a , b , b , a , a , a);

        TestCase(a , 0 , a , 0 , 0 , 0);  TestCase(b , 0 , b , 0 , 0 , 0);  TestCase(b , a , b , a , a , a);  TestCase(a , b , a , b , b , b);
        TestCase(a , 0 , a , 0 , 0 , a);  TestCase(b , 0 , b , 0 , 0 , b);  TestCase(b , a , b , a , a , b);  TestCase(a , b , a , b , b , a);
        TestCase(a , 0 , a , 0 , a , 0);  TestCase(b , 0 , b , 0 , b , 0);  TestCase(b , a , b , a , b , a);  TestCase(a , b , a , b , a , b);
        TestCase(a , 0 , a , 0 , a , a);  TestCase(b , 0 , b , 0 , b , b);  TestCase(b , a , b , a , b , b);  TestCase(a , b , a , b , a , a);

        TestCase(a , 0 , a , a , 0 , 0);  TestCase(b , 0 , b , b , 0 , 0);  TestCase(b , a , b , b , a , a);  TestCase(a , b , a , a , b , b);
        TestCase(a , 0 , a , a , 0 , a);  TestCase(b , 0 , b , b , 0 , b);  TestCase(b , a , b , b , a , b);  TestCase(a , b , a , a , b , a);
        TestCase(a , 0 , a , a , a , 0);  TestCase(b , 0 , b , b , b , 0);  TestCase(b , a , b , b , b , a);  TestCase(a , b , a , a , a , b);
        TestCase(a , 0 , a , a , a , a);  TestCase(b , 0 , b , b , b , b);  TestCase(b , a , b , b , b , b);  TestCase(a , b , a , a , a , a);

        TestCase(a , a , 0 , 0 , 0 , 0);  TestCase(b , b , 0 , 0 , 0 , 0);  TestCase(b , b , a , a , a , a);  TestCase(a , a , b , b , b , b);
        TestCase(a , a , 0 , 0 , 0 , a);  TestCase(b , b , 0 , 0 , 0 , b);  TestCase(b , b , a , a , a , b);  TestCase(a , a , b , b , b , a);
        TestCase(a , a , 0 , 0 , a , 0);  TestCase(b , b , 0 , 0 , b , 0);  TestCase(b , b , a , a , b , a);  TestCase(a , a , b , b , a , b);
        TestCase(a , a , 0 , 0 , a , a);  TestCase(b , b , 0 , 0 , b , b);  TestCase(b , b , a , a , b , b);  TestCase(a , a , b , b , a , a);

        TestCase(a , a , 0 , a , 0 , 0);  TestCase(b , b , 0 , b , 0 , 0);  TestCase(b , b , a , b , a , a);  TestCase(a , a , b , a , b , b);
        TestCase(a , a , 0 , a , 0 , a);  TestCase(b , b , 0 , b , 0 , b);  TestCase(b , b , a , b , a , b);  TestCase(a , a , b , a , b , a);
        TestCase(a , a , 0 , a , a , 0);  TestCase(b , b , 0 , b , b , 0);  TestCase(b , b , a , b , b , a);  TestCase(a , a , b , a , a , b);
        TestCase(a , a , 0 , a , a , a);  TestCase(b , b , 0 , b , b , b);  TestCase(b , b , a , b , b , b);  TestCase(a , a , b , a , a , a);

        TestCase(a , a , a , 0 , 0 , 0);  TestCase(b , b , b , 0 , 0 , 0);  TestCase(b , b , b , a , a , a);  TestCase(a , a , a , b , b , b);
        TestCase(a , a , a , 0 , 0 , a);  TestCase(b , b , b , 0 , 0 , b);  TestCase(b , b , b , a , a , b);  TestCase(a , a , a , b , b , a);
        TestCase(a , a , a , 0 , a , 0);  TestCase(b , b , b , 0 , b , 0);  TestCase(b , b , b , a , b , a);  TestCase(a , a , a , b , a , b);
        TestCase(a , a , a , 0 , a , a);  TestCase(b , b , b , 0 , b , b);  TestCase(b , b , b , a , b , b);  TestCase(a , a , a , b , a , a);

        TestCase(a , a , a , a , 0 , 0);  TestCase(b , b , b , b , 0 , 0);  TestCase(b , b , b , b , a , a);  TestCase(a , a , a , a , b , b);
        TestCase(a , a , a , a , 0 , a);  TestCase(b , b , b , b , 0 , b);  TestCase(b , b , b , b , a , b);  TestCase(a , a , a , a , b , a);
        TestCase(a , a , a , a , a , 0);  TestCase(b , b , b , b , b , 0);  TestCase(b , b , b , b , b , a);  TestCase(a , a , a , a , a , b);
        TestCase(a , a , a , a , a , a);  TestCase(b , b , b , b , b , b);  TestCase(b , b , b , b , b , b);  TestCase(a , a , a , a , a , a);
    }

    [Theory]
    [InlineData(-1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(+1 , +1)]
    [InlineData(-1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(+1024 , +1024)]
    public void TestVector3ISubtraction(int a , int b)
    {
        void TestCase(int aX , int aY , int aZ , int bX , int bY , int bZ)
        {
            Vector3I vecA = new Vector3I(aX , aY , aZ);
            Vector3I vecB = new Vector3I(bX , bY , bZ);
            Vector3I expected = new Vector3I(aX - bX , aY - bY , aZ - bZ);
            Assert.Equal(expected , vecA - vecB);
        }

        TestCase(0 , 0 , 0 , 0 , 0 , 0);  TestCase(0 , 0 , 0 , 0 , 0 , 0);  TestCase(a , a , a , a , a , a);  TestCase(b , b , b , b , b , b);
        TestCase(0 , 0 , 0 , 0 , 0 , a);  TestCase(0 , 0 , 0 , 0 , 0 , b);  TestCase(a , a , a , a , a , b);  TestCase(b , b , b , b , b , a);
        TestCase(0 , 0 , 0 , 0 , a , 0);  TestCase(0 , 0 , 0 , 0 , b , 0);  TestCase(a , a , a , a , b , a);  TestCase(b , b , b , b , a , b);
        TestCase(0 , 0 , 0 , 0 , a , a);  TestCase(0 , 0 , 0 , 0 , b , b);  TestCase(a , a , a , a , b , b);  TestCase(b , b , b , b , a , a);

        TestCase(0 , 0 , 0 , a , 0 , 0);  TestCase(0 , 0 , 0 , b , 0 , 0);  TestCase(a , a , a , b , a , a);  TestCase(b , b , b , a , b , b);
        TestCase(0 , 0 , 0 , a , 0 , a);  TestCase(0 , 0 , 0 , b , 0 , b);  TestCase(a , a , a , b , a , b);  TestCase(b , b , b , a , b , a);
        TestCase(0 , 0 , 0 , a , a , 0);  TestCase(0 , 0 , 0 , b , b , 0);  TestCase(a , a , a , b , b , a);  TestCase(b , b , b , a , a , b);
        TestCase(0 , 0 , 0 , a , a , a);  TestCase(0 , 0 , 0 , b , b , b);  TestCase(a , a , a , b , b , b);  TestCase(b , b , b , a , a , a);

        TestCase(0 , 0 , a , 0 , 0 , 0);  TestCase(0 , 0 , b , 0 , 0 , 0);  TestCase(a , a , b , a , a , a);  TestCase(b , b , a , b , b , b);
        TestCase(0 , 0 , a , 0 , 0 , a);  TestCase(0 , 0 , b , 0 , 0 , b);  TestCase(a , a , b , a , a , b);  TestCase(b , b , a , b , b , a);
        TestCase(0 , 0 , a , 0 , a , 0);  TestCase(0 , 0 , b , 0 , b , 0);  TestCase(a , a , b , a , b , a);  TestCase(b , b , a , b , a , b);
        TestCase(0 , 0 , a , 0 , a , a);  TestCase(0 , 0 , b , 0 , b , b);  TestCase(a , a , b , a , b , b);  TestCase(b , b , a , b , a , a);

        TestCase(0 , 0 , a , a , 0 , 0);  TestCase(0 , 0 , b , b , 0 , 0);  TestCase(a , a , b , b , a , a);  TestCase(b , b , a , a , b , b);
        TestCase(0 , 0 , a , a , 0 , a);  TestCase(0 , 0 , b , b , 0 , b);  TestCase(a , a , b , b , a , b);  TestCase(b , b , a , a , b , a);
        TestCase(0 , 0 , a , a , a , 0);  TestCase(0 , 0 , b , b , b , 0);  TestCase(a , a , b , b , b , a);  TestCase(b , b , a , a , a , b);
        TestCase(0 , 0 , a , a , a , a);  TestCase(0 , 0 , b , b , b , b);  TestCase(a , a , b , b , b , b);  TestCase(b , b , a , a , a , a);

        TestCase(0 , a , 0 , 0 , 0 , 0);  TestCase(0 , b , 0 , 0 , 0 , 0);  TestCase(a , b , a , a , a , a);  TestCase(b , a , b , b , b , b);
        TestCase(0 , a , 0 , 0 , 0 , a);  TestCase(0 , b , 0 , 0 , 0 , b);  TestCase(a , b , a , a , a , b);  TestCase(b , a , b , b , b , a);
        TestCase(0 , a , 0 , 0 , a , 0);  TestCase(0 , b , 0 , 0 , b , 0);  TestCase(a , b , a , a , b , a);  TestCase(b , a , b , b , a , b);
        TestCase(0 , a , 0 , 0 , a , a);  TestCase(0 , b , 0 , 0 , b , b);  TestCase(a , b , a , a , b , b);  TestCase(b , a , b , b , a , a);

        TestCase(0 , a , 0 , a , 0 , 0);  TestCase(0 , b , 0 , b , 0 , 0);  TestCase(a , b , a , b , a , a);  TestCase(b , a , b , a , b , b);
        TestCase(0 , a , 0 , a , 0 , a);  TestCase(0 , b , 0 , b , 0 , b);  TestCase(a , b , a , b , a , b);  TestCase(b , a , b , a , b , a);
        TestCase(0 , a , 0 , a , a , 0);  TestCase(0 , b , 0 , b , b , 0);  TestCase(a , b , a , b , b , a);  TestCase(b , a , b , a , a , b);
        TestCase(0 , a , 0 , a , a , a);  TestCase(0 , b , 0 , b , b , b);  TestCase(a , b , a , b , b , b);  TestCase(b , a , b , a , a , a);

        TestCase(0 , a , a , 0 , 0 , 0);  TestCase(0 , b , b , 0 , 0 , 0);  TestCase(a , b , b , a , a , a);  TestCase(b , a , a , b , b , b);
        TestCase(0 , a , a , 0 , 0 , a);  TestCase(0 , b , b , 0 , 0 , b);  TestCase(a , b , b , a , a , b);  TestCase(b , a , a , b , b , a);
        TestCase(0 , a , a , 0 , a , 0);  TestCase(0 , b , b , 0 , b , 0);  TestCase(a , b , b , a , b , a);  TestCase(b , a , a , b , a , b);
        TestCase(0 , a , a , 0 , a , a);  TestCase(0 , b , b , 0 , b , b);  TestCase(a , b , b , a , b , b);  TestCase(b , a , a , b , a , a);

        TestCase(0 , a , a , a , 0 , 0);  TestCase(0 , b , b , b , 0 , 0);  TestCase(a , b , b , b , a , a);  TestCase(b , a , a , a , b , b);
        TestCase(0 , a , a , a , 0 , a);  TestCase(0 , b , b , b , 0 , b);  TestCase(a , b , b , b , a , b);  TestCase(b , a , a , a , b , a);
        TestCase(0 , a , a , a , a , 0);  TestCase(0 , b , b , b , b , 0);  TestCase(a , b , b , b , b , a);  TestCase(b , a , a , a , a , b);
        TestCase(0 , a , a , a , a , a);  TestCase(0 , b , b , b , b , b);  TestCase(a , b , b , b , b , b);  TestCase(b , a , a , a , a , a);

        TestCase(a , 0 , 0 , 0 , 0 , 0);  TestCase(b , 0 , 0 , 0 , 0 , 0);  TestCase(b , a , a , a , a , a);  TestCase(a , b , b , b , b , b);
        TestCase(a , 0 , 0 , 0 , 0 , a);  TestCase(b , 0 , 0 , 0 , 0 , b);  TestCase(b , a , a , a , a , b);  TestCase(a , b , b , b , b , a);
        TestCase(a , 0 , 0 , 0 , a , 0);  TestCase(b , 0 , 0 , 0 , b , 0);  TestCase(b , a , a , a , b , a);  TestCase(a , b , b , b , a , b);
        TestCase(a , 0 , 0 , 0 , a , a);  TestCase(b , 0 , 0 , 0 , b , b);  TestCase(b , a , a , a , b , b);  TestCase(a , b , b , b , a , a);

        TestCase(a , 0 , 0 , a , 0 , 0);  TestCase(b , 0 , 0 , b , 0 , 0);  TestCase(b , a , a , b , a , a);  TestCase(a , b , b , a , b , b);
        TestCase(a , 0 , 0 , a , 0 , a);  TestCase(b , 0 , 0 , b , 0 , b);  TestCase(b , a , a , b , a , b);  TestCase(a , b , b , a , b , a);
        TestCase(a , 0 , 0 , a , a , 0);  TestCase(b , 0 , 0 , b , b , 0);  TestCase(b , a , a , b , b , a);  TestCase(a , b , b , a , a , b);
        TestCase(a , 0 , 0 , a , a , a);  TestCase(b , 0 , 0 , b , b , b);  TestCase(b , a , a , b , b , b);  TestCase(a , b , b , a , a , a);

        TestCase(a , 0 , a , 0 , 0 , 0);  TestCase(b , 0 , b , 0 , 0 , 0);  TestCase(b , a , b , a , a , a);  TestCase(a , b , a , b , b , b);
        TestCase(a , 0 , a , 0 , 0 , a);  TestCase(b , 0 , b , 0 , 0 , b);  TestCase(b , a , b , a , a , b);  TestCase(a , b , a , b , b , a);
        TestCase(a , 0 , a , 0 , a , 0);  TestCase(b , 0 , b , 0 , b , 0);  TestCase(b , a , b , a , b , a);  TestCase(a , b , a , b , a , b);
        TestCase(a , 0 , a , 0 , a , a);  TestCase(b , 0 , b , 0 , b , b);  TestCase(b , a , b , a , b , b);  TestCase(a , b , a , b , a , a);

        TestCase(a , 0 , a , a , 0 , 0);  TestCase(b , 0 , b , b , 0 , 0);  TestCase(b , a , b , b , a , a);  TestCase(a , b , a , a , b , b);
        TestCase(a , 0 , a , a , 0 , a);  TestCase(b , 0 , b , b , 0 , b);  TestCase(b , a , b , b , a , b);  TestCase(a , b , a , a , b , a);
        TestCase(a , 0 , a , a , a , 0);  TestCase(b , 0 , b , b , b , 0);  TestCase(b , a , b , b , b , a);  TestCase(a , b , a , a , a , b);
        TestCase(a , 0 , a , a , a , a);  TestCase(b , 0 , b , b , b , b);  TestCase(b , a , b , b , b , b);  TestCase(a , b , a , a , a , a);

        TestCase(a , a , 0 , 0 , 0 , 0);  TestCase(b , b , 0 , 0 , 0 , 0);  TestCase(b , b , a , a , a , a);  TestCase(a , a , b , b , b , b);
        TestCase(a , a , 0 , 0 , 0 , a);  TestCase(b , b , 0 , 0 , 0 , b);  TestCase(b , b , a , a , a , b);  TestCase(a , a , b , b , b , a);
        TestCase(a , a , 0 , 0 , a , 0);  TestCase(b , b , 0 , 0 , b , 0);  TestCase(b , b , a , a , b , a);  TestCase(a , a , b , b , a , b);
        TestCase(a , a , 0 , 0 , a , a);  TestCase(b , b , 0 , 0 , b , b);  TestCase(b , b , a , a , b , b);  TestCase(a , a , b , b , a , a);

        TestCase(a , a , 0 , a , 0 , 0);  TestCase(b , b , 0 , b , 0 , 0);  TestCase(b , b , a , b , a , a);  TestCase(a , a , b , a , b , b);
        TestCase(a , a , 0 , a , 0 , a);  TestCase(b , b , 0 , b , 0 , b);  TestCase(b , b , a , b , a , b);  TestCase(a , a , b , a , b , a);
        TestCase(a , a , 0 , a , a , 0);  TestCase(b , b , 0 , b , b , 0);  TestCase(b , b , a , b , b , a);  TestCase(a , a , b , a , a , b);
        TestCase(a , a , 0 , a , a , a);  TestCase(b , b , 0 , b , b , b);  TestCase(b , b , a , b , b , b);  TestCase(a , a , b , a , a , a);

        TestCase(a , a , a , 0 , 0 , 0);  TestCase(b , b , b , 0 , 0 , 0);  TestCase(b , b , b , a , a , a);  TestCase(a , a , a , b , b , b);
        TestCase(a , a , a , 0 , 0 , a);  TestCase(b , b , b , 0 , 0 , b);  TestCase(b , b , b , a , a , b);  TestCase(a , a , a , b , b , a);
        TestCase(a , a , a , 0 , a , 0);  TestCase(b , b , b , 0 , b , 0);  TestCase(b , b , b , a , b , a);  TestCase(a , a , a , b , a , b);
        TestCase(a , a , a , 0 , a , a);  TestCase(b , b , b , 0 , b , b);  TestCase(b , b , b , a , b , b);  TestCase(a , a , a , b , a , a);

        TestCase(a , a , a , a , 0 , 0);  TestCase(b , b , b , b , 0 , 0);  TestCase(b , b , b , b , a , a);  TestCase(a , a , a , a , b , b);
        TestCase(a , a , a , a , 0 , a);  TestCase(b , b , b , b , 0 , b);  TestCase(b , b , b , b , a , b);  TestCase(a , a , a , a , b , a);
        TestCase(a , a , a , a , a , 0);  TestCase(b , b , b , b , b , 0);  TestCase(b , b , b , b , b , a);  TestCase(a , a , a , a , a , b);
        TestCase(a , a , a , a , a , a);  TestCase(b , b , b , b , b , b);  TestCase(b , b , b , b , b , b);  TestCase(a , a , a , a , a , a);
    }
    #endregion


    #region Test vector length
    [Theory]
    [InlineData(0 , 0)]
    [InlineData(+1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(-1 , -1)]
    [InlineData(+1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(-1024 , -1024)]
    public void TestVector2DLength(double x , double z)
    {
        double expected = Math.Sqrt(x * x + z * z);
        Assert.Equal(expected , new Vector2D(x , z).Length());
    }

    [Theory]
    [InlineData(0 , 0)]
    [InlineData(+1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(-1 , -1)]
    [InlineData(+1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(-1024 , -1024)]
    public void TestVector2ILength(int x , int z)
    {
        double expected = Math.Sqrt(x * x + z * z);
        Assert.Equal(expected , new Vector2I(x , z).Length());
    }

    [Theory]
    [InlineData(0 , 0 , 0)]
    [InlineData(+1 , +1 , +1)]
    [InlineData(+1 , +1 , -1)]
    [InlineData(+1 , -1 , +1)]
    [InlineData(+1 , -1 , -1)]
    [InlineData(-1 , +1 , +1)]
    [InlineData(-1 , +1 , -1)]
    [InlineData(-1 , -1 , +1)]
    [InlineData(-1 , -1 , -1)]
    [InlineData(+1024 , +1024 , +1024)]
    [InlineData(+1024 , +1024 , -1024)]
    [InlineData(+1024 , -1024 , +1024)]
    [InlineData(+1024 , -1024 , -1024)]
    [InlineData(-1024 , +1024 , +1024)]
    [InlineData(-1024 , +1024 , -1024)]
    [InlineData(-1024 , -1024 , +1024)]
    [InlineData(-1024 , -1024 , -1024)]
    public void TestVector3DLength(double x , double y , double z)
    {
        double expected = Math.Sqrt(x * x + y * y + z * z);
        Assert.Equal(expected , new Vector3D(x , y , z).Length());
    }

    [Theory]
    [InlineData(0 , 0 , 0)]
    [InlineData(+1 , +1 , +1)]
    [InlineData(+1 , +1 , -1)]
    [InlineData(+1 , -1 , +1)]
    [InlineData(+1 , -1 , -1)]
    [InlineData(-1 , +1 , +1)]
    [InlineData(-1 , +1 , -1)]
    [InlineData(-1 , -1 , +1)]
    [InlineData(-1 , -1 , -1)]
    [InlineData(+1024 , +1024 , +1024)]
    [InlineData(+1024 , +1024 , -1024)]
    [InlineData(+1024 , -1024 , +1024)]
    [InlineData(+1024 , -1024 , -1024)]
    [InlineData(-1024 , +1024 , +1024)]
    [InlineData(-1024 , +1024 , -1024)]
    [InlineData(-1024 , -1024 , +1024)]
    [InlineData(-1024 , -1024 , -1024)]
    public void TestVector3ILength(int x , int y , int z)
    {
        double expected = Math.Sqrt(x * x + y * y + z * z);
        Assert.Equal(expected , new Vector3I(x , y , z).Length());
    }
    #endregion

    #region Test vector get max entry
    [Theory]
    [InlineData(0 , 0)]
    [InlineData(+1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(-1 , -1)]
    [InlineData(+1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(-1024 , -1024)]
    public void TestVector2DGetMaxEntry(double x , double z)
    {
        double expected = new[] { x , z }.Max();
        Assert.Equal(expected , new Vector2D(x , z).GetMaxEntry());
    }

    [Theory]
    [InlineData(0 , 0)]
    [InlineData(+1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(-1 , -1)]
    [InlineData(+1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(-1024 , -1024)]
    public void TestVector2IGetMaxEntry(int x , int z)
    {
        int expected = new[] { x , z }.Max();
        Assert.Equal(expected , new Vector2I(x , z).GetMaxEntry());
    }

    [Theory]
    [InlineData(0 , 0 , 0)]
    [InlineData(+1 , +1 , +1)]
    [InlineData(+1 , +1 , -1)]
    [InlineData(+1 , -1 , +1)]
    [InlineData(+1 , -1 , -1)]
    [InlineData(-1 , +1 , +1)]
    [InlineData(-1 , +1 , -1)]
    [InlineData(-1 , -1 , +1)]
    [InlineData(-1 , -1 , -1)]
    [InlineData(+1024 , +1024 , +1024)]
    [InlineData(+1024 , +1024 , -1024)]
    [InlineData(+1024 , -1024 , +1024)]
    [InlineData(+1024 , -1024 , -1024)]
    [InlineData(-1024 , +1024 , +1024)]
    [InlineData(-1024 , +1024 , -1024)]
    [InlineData(-1024 , -1024 , +1024)]
    [InlineData(-1024 , -1024 , -1024)]
    public void TestVector3DGetMaxEntry(double x , double y , double z)
    {
        double expected = new[] { x , y , z }.Max();
        Assert.Equal(expected , new Vector3D(x , y , z).GetMaxEntry());
    }

    [Theory]
    [InlineData(0 , 0 , 0)]
    [InlineData(+1 , +1 , +1)]
    [InlineData(+1 , +1 , -1)]
    [InlineData(+1 , -1 , +1)]
    [InlineData(+1 , -1 , -1)]
    [InlineData(-1 , +1 , +1)]
    [InlineData(-1 , +1 , -1)]
    [InlineData(-1 , -1 , +1)]
    [InlineData(-1 , -1 , -1)]
    [InlineData(+1024 , +1024 , +1024)]
    [InlineData(+1024 , +1024 , -1024)]
    [InlineData(+1024 , -1024 , +1024)]
    [InlineData(+1024 , -1024 , -1024)]
    [InlineData(-1024 , +1024 , +1024)]
    [InlineData(-1024 , +1024 , -1024)]
    [InlineData(-1024 , -1024 , +1024)]
    [InlineData(-1024 , -1024 , -1024)]
    public void TestVector3IGetMaxEntry(int x , int y , int z)
    {
        double expected = new[] { x , y , z }.Max();
        Assert.Equal(expected , new Vector3I(x , y , z).GetMaxEntry());
    }
    #endregion

    #region Test vector get min entry
    [Theory]
    [InlineData(0 , 0)]
    [InlineData(+1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(-1 , -1)]
    [InlineData(+1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(-1024 , -1024)]
    public void TestVector2DGetMinEntry(double x , double z)
    {
        double expected = new[] { x , z }.Min();
        Assert.Equal(expected , new Vector2D(x , z).GetMinEntry());
    }

    [Theory]
    [InlineData(0 , 0)]
    [InlineData(+1 , +1)]
    [InlineData(+1 , -1)]
    [InlineData(-1 , +1)]
    [InlineData(-1 , -1)]
    [InlineData(+1024 , +1024)]
    [InlineData(+1024 , -1024)]
    [InlineData(-1024 , +1024)]
    [InlineData(-1024 , -1024)]
    public void TestVector2IGetMinEntry(int x , int z)
    {
        int expected = new[] { x , z }.Min();
        Assert.Equal(expected , new Vector2I(x , z).GetMinEntry());
    }

    [Theory]
    [InlineData(0 , 0 , 0)]
    [InlineData(+1 , +1 , +1)]
    [InlineData(+1 , +1 , -1)]
    [InlineData(+1 , -1 , +1)]
    [InlineData(+1 , -1 , -1)]
    [InlineData(-1 , +1 , +1)]
    [InlineData(-1 , +1 , -1)]
    [InlineData(-1 , -1 , +1)]
    [InlineData(-1 , -1 , -1)]
    [InlineData(+1024 , +1024 , +1024)]
    [InlineData(+1024 , +1024 , -1024)]
    [InlineData(+1024 , -1024 , +1024)]
    [InlineData(+1024 , -1024 , -1024)]
    [InlineData(-1024 , +1024 , +1024)]
    [InlineData(-1024 , +1024 , -1024)]
    [InlineData(-1024 , -1024 , +1024)]
    [InlineData(-1024 , -1024 , -1024)]
    public void TestVector3DGetMinEntry(double x , double y , double z)
    {
        double expected = new[] { x , y , z }.Min();
        Assert.Equal(expected , new Vector3D(x , y , z).GetMinEntry());
    }

    [Theory]
    [InlineData(0 , 0 , 0)]
    [InlineData(+1 , +1 , +1)]
    [InlineData(+1 , +1 , -1)]
    [InlineData(+1 , -1 , +1)]
    [InlineData(+1 , -1 , -1)]
    [InlineData(-1 , +1 , +1)]
    [InlineData(-1 , +1 , -1)]
    [InlineData(-1 , -1 , +1)]
    [InlineData(-1 , -1 , -1)]
    [InlineData(+1024 , +1024 , +1024)]
    [InlineData(+1024 , +1024 , -1024)]
    [InlineData(+1024 , -1024 , +1024)]
    [InlineData(+1024 , -1024 , -1024)]
    [InlineData(-1024 , +1024 , +1024)]
    [InlineData(-1024 , +1024 , -1024)]
    [InlineData(-1024 , -1024 , +1024)]
    [InlineData(-1024 , -1024 , -1024)]
    public void TestVector3IGetMinEntry(int x , int y , int z)
    {
        double expected = new[] { x , y , z }.Min();
        Assert.Equal(expected , new Vector3I(x , y , z).GetMinEntry());
    }
    #endregion



    [Theory]
    [InlineData(+1 ,  0 , -90 )]  // +- Cardinal direction
    [InlineData(-1 ,  0 , +90 )]  // |
    [InlineData( 0 , +1 ,  0  )]  // |
    [InlineData( 0 , -1 , -180)]  // \_
    [InlineData(+1 , +1 , -45 )]  // +- Ordinal direction
    [InlineData(+1 , -1 , -135)]  // |
    [InlineData(-1 , +1 , +45 )]  // |
    [InlineData(-1 , -1 , +135)]  // \_
    public void TestVectorGetHorizontalWorldAngle(int x , int z , double angle)
    {
        Assert.Equal(angle , new Vector2D(x , z).ToHorizontalWorldAngle());
        Assert.Equal(angle , new Vector2I(x , z).ToHorizontalWorldAngle());

        Assert.Equal(angle , new Vector3D(x , 0 , z).ToHorizontalWorldAngle());
        Assert.Equal(angle , new Vector3I(x , 0 , z).ToHorizontalWorldAngle());
        Assert.Equal(angle , new Vector3D(x , 128 , z).ToHorizontalWorldAngle());
        Assert.Equal(angle , new Vector3I(x , 128 , z).ToHorizontalWorldAngle());
        Assert.Equal(angle , new Vector3D(x , 256 , z).ToHorizontalWorldAngle());
        Assert.Equal(angle , new Vector3I(x , 256 , z).ToHorizontalWorldAngle());
    }

    [Theory]
    [InlineData(+1 , +1 ,  0 , +45)]
    [InlineData(-1 , +1 ,  0 , +45)]
    [InlineData( 0 , +1 , +1 , +45)]
    [InlineData( 0 , +1 , -1 , +45)]
    [InlineData(+1 , -1 ,  0 , -45)]
    [InlineData(-1 , -1 ,  0 , -45)]
    [InlineData( 0 , -1 , +1 , -45)]
    [InlineData( 0 , -1 , -1 , -45)]
    [InlineData(+1 ,  0 , +1 ,  0 )]
    [InlineData(+1 ,  0 , -1 ,  0 )]
    [InlineData(-1 ,  0 , +1 ,  0 )]
    [InlineData(-1 ,  0 , -1 ,  0 )]
    public void TestVectorGetVerticalWorldAngle(int x , int y , int z , double angle)
    {
        Assert.Equal(0 , new Vector2D(x , z).ToVerticalWorldAngle());
        Assert.Equal(0 , new Vector2I(x , z).ToVerticalWorldAngle());

        Assert.Equal(angle , new Vector3D(x , y , z).ToVerticalWorldAngle());
        Assert.Equal(angle , new Vector3I(x , y , z).ToVerticalWorldAngle());
    }



    [Theory]
    [InlineData( 0 ,  0 , false)]
    [InlineData( 0 ,            -1 , true )]  // +- Cardinal direction
    [InlineData( 0 ,            +1 , false)]  // |
    [InlineData(-1 ,             0 , false)]  // |
    [InlineData(+1 ,             0 , false)]  // |
    [InlineData( 0 , -int.MaxValue , true )]  // |
    [InlineData( 0 , +int.MaxValue , false)]  // |
    [InlineData(-int.MaxValue ,  0 , false)]  // |
    [InlineData(+int.MaxValue ,  0 , false)]  // \_
    [InlineData(-1 , -1 , true )]  // +- Ordinal direction
    [InlineData(+1 , -1 , true )]  // |
    [InlineData(-1 , +1 , false)]  // |
    [InlineData(+1 , +1 , false)]  // \_
    [InlineData(-1 , -2 , true )]
    [InlineData(+1 , -2 , true )]
    [InlineData(-1 , +2 , false)]
    [InlineData(+1 , +2 , false)]
    [InlineData(-2 , -1 , false)]
    [InlineData(-2 , +1 , false)]
    [InlineData(+2 , -1 , false)]
    [InlineData(+2 , +1 , false)]
    public void TestVectorIsNorth(int x , int z , bool expectedResult)
    {
        Vector2D vec2D = new Vector2D(x , z);
        Assert.Equal(expectedResult , vec2D.IsNorth());

        Vector2I vec2I = new Vector2I(x , z);
        Assert.Equal(expectedResult , vec2I.IsNorth());

        Vector3D vec3D0 = new Vector3D(x , 0 , z);
        Assert.Equal(expectedResult , vec3D0.IsNorth());

        Vector3D vec3D128 = new Vector3D(x , 128 , z);
        Assert.Equal(expectedResult , vec3D128.IsNorth());

        Vector3D vec3D255 = new Vector3D(x , 255 , z);
        Assert.Equal(expectedResult , vec3D255.IsNorth());

        Vector3I vec3I0 = new Vector3I(x , 0 , z);
        Assert.Equal(expectedResult , vec3I0.IsNorth());

        Vector3I vec3I128 = new Vector3I(x , 0 , z);
        Assert.Equal(expectedResult , vec3I128.IsNorth());

        Vector3I vec3I255 = new Vector3I(x , 255 , z);
        Assert.Equal(expectedResult , vec3I255.IsNorth());
    }

    [Theory]
    [InlineData( 0 ,  0 , false)]
    [InlineData( 0 ,            -1 , false)]  // +- Cardinal direction
    [InlineData( 0 ,            +1 , true )]  // |
    [InlineData(-1 ,             0 , false)]  // |
    [InlineData(+1 ,             0 , false)]  // |
    [InlineData( 0 , -int.MaxValue , false)]  // |
    [InlineData( 0 , +int.MaxValue , true )]  // |
    [InlineData(-int.MaxValue ,  0 , false)]  // |
    [InlineData(+int.MaxValue ,  0 , false)]  // \_
    [InlineData(-1 , -1 , false)]  // +- Ordinal direction
    [InlineData(+1 , -1 , false)]  // |
    [InlineData(-1 , +1 , true )]  // |
    [InlineData(+1 , +1 , true )]  // \_
    [InlineData(-1 , -2 , false)]
    [InlineData(+1 , -2 , false)]
    [InlineData(-1 , +2 , true )]
    [InlineData(+1 , +2 , true )]
    [InlineData(-2 , -1 , false)]
    [InlineData(-2 , +1 , false)]
    [InlineData(+2 , -1 , false)]
    [InlineData(+2 , +1 , false)]
    public void TestVectorIsSouth(int x , int z , bool expectedResult)
    {
        Vector2D vec2D = new Vector2D(x , z);
        Assert.Equal(expectedResult , vec2D.IsSouth());

        Vector2I vec2I = new Vector2I(x , z);
        Assert.Equal(expectedResult , vec2I.IsSouth());

        Vector3D vec3D0 = new Vector3D(x , 0 , z);
        Assert.Equal(expectedResult , vec3D0.IsSouth());

        Vector3D vec3D128 = new Vector3D(x , 128 , z);
        Assert.Equal(expectedResult , vec3D128.IsSouth());

        Vector3D vec3D255 = new Vector3D(x , 255 , z);
        Assert.Equal(expectedResult , vec3D255.IsSouth());

        Vector3I vec3I0 = new Vector3I(x , 0 , z);
        Assert.Equal(expectedResult , vec3I0.IsSouth());

        Vector3I vec3I128 = new Vector3I(x , 0 , z);
        Assert.Equal(expectedResult , vec3I128.IsSouth());

        Vector3I vec3I255 = new Vector3I(x , 255 , z);
        Assert.Equal(expectedResult , vec3I255.IsSouth());
    }

    [Theory]
    [InlineData( 0 ,  0 , false)]
    [InlineData( 0 ,            -1 , false)]  // +- Cardinal direction
    [InlineData( 0 ,            +1 , false)]  // |
    [InlineData(-1 ,             0 , true )]  // |
    [InlineData(+1 ,             0 , false)]  // |
    [InlineData( 0 , -int.MaxValue , false)]  // |
    [InlineData( 0 , +int.MaxValue , false)]  // |
    [InlineData(-int.MaxValue ,  0 , true )]  // |
    [InlineData(+int.MaxValue ,  0 , false)]  // \_
    [InlineData(-1 , -1 , true )]  // +- Ordinal direction
    [InlineData(+1 , -1 , false)]  // |
    [InlineData(-1 , +1 , true )]  // |
    [InlineData(+1 , +1 , false)]  // \_
    [InlineData(-1 , -2 , false)]
    [InlineData(+1 , -2 , false)]
    [InlineData(-1 , +2 , false)]
    [InlineData(+1 , +2 , false)]
    [InlineData(-2 , -1 , true )]
    [InlineData(-2 , +1 , true )]
    [InlineData(+2 , -1 , false)]
    [InlineData(+2 , +1 , false)]
    public void TestVectorIsWest(int x , int z , bool expectedResult)
    {
        Vector2D vec2D = new Vector2D(x , z);
        Assert.Equal(expectedResult , vec2D.IsWest());

        Vector2I vec2I = new Vector2I(x , z);
        Assert.Equal(expectedResult , vec2I.IsWest());

        Vector3D vec3D0 = new Vector3D(x , 0 , z);
        Assert.Equal(expectedResult , vec3D0.IsWest());

        Vector3D vec3D128 = new Vector3D(x , 128 , z);
        Assert.Equal(expectedResult , vec3D128.IsWest());

        Vector3D vec3D255 = new Vector3D(x , 255 , z);
        Assert.Equal(expectedResult , vec3D255.IsWest());

        Vector3I vec3I0 = new Vector3I(x , 0 , z);
        Assert.Equal(expectedResult , vec3I0.IsWest());

        Vector3I vec3I128 = new Vector3I(x , 0 , z);
        Assert.Equal(expectedResult , vec3I128.IsWest());

        Vector3I vec3I255 = new Vector3I(x , 255 , z);
        Assert.Equal(expectedResult , vec3I255.IsWest());
    }

    [Theory]
    [InlineData( 0 ,  0 , false)]
    [InlineData( 0 ,            -1 , false)]  // +- Cardinal direction
    [InlineData( 0 ,            +1 , false)]  // |
    [InlineData(-1 ,             0 , false)]  // |
    [InlineData(+1 ,             0 , true )]  // |
    [InlineData( 0 , -int.MaxValue , false)]  // |
    [InlineData( 0 , +int.MaxValue , false)]  // |
    [InlineData(-int.MaxValue ,  0 , false)]  // |
    [InlineData(+int.MaxValue ,  0 , true )]  // \_
    [InlineData(-1 , -1 , false)]  // +- Ordinal direction
    [InlineData(+1 , -1 , true )]  // |
    [InlineData(-1 , +1 , false)]  // |
    [InlineData(+1 , +1 , true )]  // \_
    [InlineData(-1 , -2 , false)]
    [InlineData(+1 , -2 , false)]
    [InlineData(-1 , +2 , false)]
    [InlineData(+1 , +2 , false)]
    [InlineData(-2 , -1 , false)]
    [InlineData(-2 , +1 , false)]
    [InlineData(+2 , -1 , true )]
    [InlineData(+2 , +1 , true )]
    public void TestVectorIsEast(int x , int z , bool expectedResult)
    {
        Vector2D vec2D = new Vector2D(x , z);
        Assert.Equal(expectedResult , vec2D.IsEast());

        Vector2I vec2I = new Vector2I(x , z);
        Assert.Equal(expectedResult , vec2I.IsEast());

        Vector3D vec3D0 = new Vector3D(x , 0 , z);
        Assert.Equal(expectedResult , vec3D0.IsEast());

        Vector3D vec3D128 = new Vector3D(x , 128 , z);
        Assert.Equal(expectedResult , vec3D128.IsEast());

        Vector3D vec3D255 = new Vector3D(x , 255 , z);
        Assert.Equal(expectedResult , vec3D255.IsEast());

        Vector3I vec3I0 = new Vector3I(x , 0 , z);
        Assert.Equal(expectedResult , vec3I0.IsEast());

        Vector3I vec3I128 = new Vector3I(x , 0 , z);
        Assert.Equal(expectedResult , vec3I128.IsEast());

        Vector3I vec3I255 = new Vector3I(x , 255 , z);
        Assert.Equal(expectedResult , vec3I255.IsEast());
    }
}
