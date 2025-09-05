
public class TestAuthor {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Author author = new Author("Adriano", "adriano@gmail.com", 'm');
		
		System.out.printf("Nome: %s \n", author.getName() );
		System.out.printf("Email: %s \n", author.getEmail() );
		System.out.printf("Genero: %c \n", author.getGender() );
		System.out.printf("---------------------------\n");
		
		author.setEmail("driano@hotmail.com");
		System.out.printf(author.toString());
	}

}
