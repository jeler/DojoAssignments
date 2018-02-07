function zeronegativity(array)
{
    var pos = true;
    for(var i =0; i<array.length; i++)
    {
        if(array[i] < 1)
        {
            pos = false;
        } 
    }
    return pos;
}

function is_even(num)
{
    if(num % 2 == 0)
    {
        return true;
    }
    else{
        return false;
    }
}

function how_many_even(arr)
{
    var count = 0;
    for(var i = 0; i<arr.length; i++)
    {
        if(arr[i] % 2 == 0)
        {
            // console.log("Got here!");
            count++;
            // console.log(count);
        }
    }
    return count;
}

function how_many_even2(arr)
{
    var count = 0;
    for(var i = 0; i<arr.length; i++)
    {
        if(is_even(arr[i]) == true)
        {
            count++
        }
        
    }
    return count;
}

function create_dummy_array(n)
{
    
    var newArray = [];
    {
        for(var i =0; i<n; i++ )
        {
            var random = Math.floor(Math.random() * 10);
            newArray.push(random);
        }
        return newArray;
    }
}

function random_choice(arr)
{
    var random = Math.floor(Math.random() * arr.length)
    return arr[random];
}
    
var test1 = zeronegativity([1,3,4,6,-2]);
console.log(test1);
var test2 = zeronegativity([1,2,4,5,6]);
console.log(test2)
var test3 = is_even(5)
console.log(test3);
var test4 = is_even(6);
console.log(test4);
var test5 = how_many_even([1,3,4,6,-2]);
console.log(test5);
var test6 = how_many_even2([1,3,4,6,-2]);
console.log(test6);
var test7 = create_dummy_array(6);
console.log(test7);
var test8 = random_choice([2,4,3,6,7]);
console.log(test8);



