function fancyArrays(arr,symbol,reversed) 
{
    if (reversed === false) 
    {
        for(var i =0; i < arr.length; i++) 
        {
        console.log(i + " " + symbol + " " + arr[i]);
        }
    }
    else
    {
        for(var j= arr.length-1; j > 0; j--)  
        {
        console.log(j + " " + symbol + " " + arr[j]);
        }
    }
}
fancyArrays(["Jill","Jane","Joe","Jerald"], "=>", true);