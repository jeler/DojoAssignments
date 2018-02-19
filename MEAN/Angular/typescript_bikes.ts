class Bike
{
    constructor(public price: number, public max_speed: number, public miles: number = 0) {
        this.price = price;
        this.max_speed = max_speed;
    }
    display_info() {
        console.log(`Price: ${this.price} Max Speed: ${this.max_speed} Miles: ${this.miles}`);
        return this;
    }
    ride()
    {
        this.miles += 10;
        console.log("Riding")
        return this;
    }
    reverse()
    {
        if (this.miles > 5)
        {
            this.miles -= 5;
        }
        else
        {
            this.miles = 0;
        }
        return this;
    }
}

    var schwinn = new Bike(41, 50);
schwinn.ride().ride().reverse().display_info();

