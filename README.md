# FastTechFoods API Gateway

### Descrição
> É uma aplicação em arquitetura de microsserviços, utilizando o Kubernetes para gerenciamento de conteinerização, orquestração e escalabilidade.


<details>
  <summary><strong>Inicializar os pods</strong></summary>
  
### Criar o Banco de Dados SQL Server
  ```
  kubectl apply -f .\k8s\mssql\pvc.yaml -f .\k8s\mssql\secret.yaml
  kubectl apply -f .\k8s\mssql
  ```

### Criar o Banco de Dados Mongo
  ```
  kubectl apply -f .\k8s\mongodb\pvc.yaml -f .\k8s\mongodb
  ```

  ### Criar o RabbitMQ
  ```
  kubectl apply -f .\k8s\rabbitmq\secret.yaml
  kubectl apply -f .\k8s\rabbitmq
  ```

  ### Criar a Observabilidade
  ```
  kubectl apply -f .\k8s\observability\prometheus\pvc.yaml
  kubectl apply -f .\k8s\observability\prometheus
  kubectl apply -f .\k8s\observability\grafana\pvc.yaml
  kubectl apply -f .\k8s\observability\grafana
  ```

  ### Criar os Microserviços

Fazer os apply diretamente no diretório/repo de cada MS


  ### Criar a API Gateway
  ```
  kubectl apply -f .\k8s
  ```
</details>

<details>
  <summary><strong>Comandos básicos de Kubernetes</strong></summary>

  ### Visualizar
  ```
  kubectl get secrets

  kubectl get pv,pvc

  kubectl get pods,deployment,svc
  
  kubectl get deployment,svc -l app=contact-api
  
  kubectl describe deployment/api-gateway
  
  kubectl logs pods/contact-persistence-9b887cd7d-htr5r --tail=50
  ```
  
  ### Interação
  ```
  kubectl apply -f deployment.yaml
  
  kubectl delete deployment/api-gateway
  
  kubectl delete deployment,svc -l app=contact-api

  kubectl delete configmaps --all
  
  # Editar sem rebuildar a imagem
  kubectl edit configmap api-gateway-config
  
  kubectl rollout restart deployment api-gateway
  ```
</details>
