function magic_multiply(x, y)
{
    // --- your code here ---
    if(typeof x =="number" && typeof y == "number")
    {
        return x * y;    
    }
    else if (x.constructor == Array && typeof y =="number")
    {
        for(var i = 0; i < x.length; i++)
        {      
            x[i] = x[i]*2;
        }
            return x;
    }
    else if((typeof x == "number" && typeof y == "string"))
    {
        if (isNaN(x*y)) 
        {
            var message = "Error: You can not multiply a string by a number!"
            // console.log(message);
            return message;
        }
    }

    else if(typeof x =="string" && typeof y =="number")
    
    var NewString = "";

    {
       for(var i = 0; i< y; i++)
       {
           
           NewString += x

       }
       return NewString    
    }
}

let test1 = magic_multiply(5, 2);
console.log(test1);

let test2 = magic_multiply(0, 0);
console.log(test2);

let test3 = magic_multiply([1, 2, 3], 2);
console.log(test3);

let test4 = magic_multiply(7, "three");
console.log(test4);

let test5 = magic_multiply("Brendo", 4);
console.log(test5);