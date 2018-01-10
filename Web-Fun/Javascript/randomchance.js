function randomChance(quarters) {
    var count = 0;
    while(quarters > 0) {
        var slotResult = Math.floor(Math.random() * 100) + 1; //chance of winning
        var winnings = Math.floor(Math.random()*50) + 50 //amount of winnings
        var winningNumber = Math.floor(Math.random()*100) + 1 //winning number
        if(slotResult === winningNumber) {
            quarters+=winnings;
            return quarters;
        }
        else {
        quarters--;
        count++;
        }
    console.log(count);
    }
}
console.log(randomChance(1500));