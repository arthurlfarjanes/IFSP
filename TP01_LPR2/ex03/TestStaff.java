package ex03;

public class TestStaff {

	public static void main(String[] args) {
		Staff staffMember = new Staff("Carlos", "São Vicente", "IFSP", 3500.50);
		
		System.out.println("--- Testando os Getters Iniciais ---");
		System.out.printf("Nome: %s\n", staffMember.getName());
		System.out.printf("Endereço: %s\n", staffMember.getAdress());
		System.out.printf("Escola: %s\n", staffMember.getSchool());
		System.out.printf("Salário: %.2f\n", staffMember.getPay());
		System.out.println("-------------------------------------\n");
		
		staffMember.setAdress("Praia Grande");
		staffMember.setSchool("ETEC");
		staffMember.setPay(4200.00);
		
		System.out.println("--- Testando os Getters Após os Setters ---");
		System.out.printf("Novo Endereço: %s\n", staffMember.getAdress());
		System.out.printf("Nova Escola: %s\n", staffMember.getSchool());
		System.out.printf("Novo Salário: %.2f\n", staffMember.getPay());
		System.out.println("-------------------------------------\n");
		
		System.out.println("--- Testando o método toString() ---");
		System.out.println(staffMember.toString());
		System.out.println("-------------------------------------\n");
	}
	
}
