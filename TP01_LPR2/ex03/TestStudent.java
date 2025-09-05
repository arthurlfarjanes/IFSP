package ex03;

public class TestStudent {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Student student = new Student("Adriano", "cubatao", "matematica", 2025, 20.00);
	
		System.out.printf("Nome: %s\n", student.getName());
		System.out.printf("Adress: %s\n", student.getAdress());
		System.out.printf("Program: %s\n", student.getProgram());
		System.out.printf("Ano: %d\n", student.getYear());
		System.out.printf("Taxa: %.2f\n", student.getFee());
		System.out.printf("---------------------\n");
	
		student.setAdress("Santos");
		student.setProgram("Historia");
		student.setYear(2020);
		student.setFee(40.00);
		
		System.out.printf("%s", student.toString());
	}

}
