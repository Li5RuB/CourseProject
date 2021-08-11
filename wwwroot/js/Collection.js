class Collection{
    constructor(title,topic,description,urlimg) {
        this.title = title;
        this.topic = topic;
        this.description = description;
        this.urlimg = urlimg;
        this.CollectionsCard;    
    }
    CreateCard(){
        this.CollectionsCard = document.createElement('div');
        this.CollectionsCard.className = "card";
        this.CollectionsCard.appendChild(CreateImage());
    }

    CreateCollection() {
        CreateCard()
        CreateCardsTitle();
        CreateCardsTopic();
        CreateCardsText();
        CreateCardsButton();
        return this.CollectionsCard
    }

    CreateImage() {
        let childimg = document.createElement('img');
        childimg.className = "card-img-top";
        childimg.src = urlimg;
        childimg.alt = "Image not loaded"
        return childimg;
    }

    CreateCardsTitle() {
        let title = document.createElement('h5');
        title.className = "card-title";
        title.innerHTML = this.title;
        this.CollectionsCard.appendChild(title);
    }
    
    CreateCardsTopic() {
        let topic = document.createElement('h7');
        topic.className = "card-title";
        topic.innerHTML = this.topic;
        this.CollectionsCard.appendChild(topic);
    }
    
    CreateCardsText() {
        let text = document.createElement('p');
        text.className = "card - text";
        text.innerHTML = this.description;
        this.CollectionsCard.appendChild(text);
    }
    
    CreateCardsButton() {
        let drow = document.createElement('div');
        drow.className = "row justify-content-end";
        drow.innerHTML = '<a href="#" class="btn btn-primary">Viewing</a>< a href = "#" class="btn btn-warning" > Edit</a ><a href="#" class="btn btn-secondary">Remove</a>'
        this.CollectionsCard.appendChild(drow);
    }
}
    
function CreateCollCard(place, title, topic, description, urlimg) {
    let collection = new Collection(title, topic, description, urlimg); 
    document.getElementById(place).append(collection.CreateCollection());
}