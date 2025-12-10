import hashlib # Biblioteca que contém as funções de criptografia

def criar_hash(texto):
    """
    Função que recebe um texto e devolve o seu Hash SHA-256.
    """
    # 1. Converter o texto para bytes (computadores trabalham com bytes)
    texto_em_bytes = texto.encode('utf-8')
    
    # 2. Criar o objeto hash usando o algoritmo SHA-256
    objeto_hash = hashlib.sha256(texto_em_bytes)
    
    # 3. Obter o código final em formato hexadecimal (letras e números)
    hash_final = objeto_hash.hexdigest()
    
    return hash_final

def main():
    print("--- SISTEMA DE SEGURANÇA: DEMONSTRAÇÃO DE HASH ---")
    
    # --- ETAPA 1: CADASTRO (Simulação) ---
    print("\n[ETAPA 1] Vamos cadastrar uma senha segura.")
    senha_original = input("Digite a sua senha para cadastro: ")
    
    # Geramos o hash da senha para guardar
    hash_guardado = criar_hash(senha_original)
    
    print(f"\nSucesso! A senha foi guardada.")
    print(f"ATENÇÃO: Não guardamos '{senha_original}'.")
    print(f"Guardamos apenas a impressão digital (Hash):")
    print(f"--> {hash_guardado}")
    print("-" * 50)
    
    # --- ETAPA 2: LOGIN (Verificação) ---
    print("\n[ETAPA 2] Agora, tente fazer login.")
    senha_tentativa = input("Digite a sua senha novamente: ")
    
    # Geramos o hash da tentativa
    hash_tentativa = criar_hash(senha_tentativa)
    
    print(f"\nHash da tentativa: {hash_tentativa}")
    print(f"Hash original:     {hash_guardado}")
    
    # Comparação
    if hash_tentativa == hash_guardado:
        print("\nRESULTADO: ✅ Acesso Permitido! As digitais coincidem.")
    else:
        print("\nRESULTADO: ❌ Acesso Negado! As senhas são diferentes.")

# Executa o programa principal
if __name__ == "__main__":
    main()