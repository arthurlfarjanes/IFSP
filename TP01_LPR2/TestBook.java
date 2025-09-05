public class TestBook {

	public static void main(String[] args) {
		Author[] authors = new Author[2];
		
		authors[0] = new Author("Autor 01", "autor01@somewhere.com.br", 'm');
		authors[1] = new Author("Autora 02", "autora02@nowhere.com.br", 'f');
		
		Book javaBook = new Book("Java for Dummies", authors, 29.99, 150);
		
		System.out.println("--- Testando o método toString() ---");
		System.out.println(javaBook.toString());
		System.out.println("-------------------------------------\n");
		
		System.out.println("--- Testando o método getAuthorNames() ---");
		System.out.println("Nomes dos autores: " + javaBook.getAuthorNames());
		System.out.println("-------------------------------------\n");
	}
}