function setup() { }
class Comment {
    constructor(text, author) {
        let container = select('#comments');
        this.carddiv = createDiv('').addClass('card').parent(container).addClass('py-2');
        this.cardBody = createDiv('').addClass('card-body').parent(this.carddiv);
        this.title = createElement('h5').addClass('card-title').html(author).parent(this.cardBody);
        this.description = createElement('p').addClass('card-text').html(text).parent(this.cardBody);
    }
}
function CreateComment(text,author) {
    let comment = new Comment(text, author);
}