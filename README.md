# FastTechFoods API Gateway

### Descrição
> É uma aplicação em arquitetura de microsserviços, utilizando o Kubernetes para gerenciamento de conteinerização, orquestração e escalabilidade.


<details>
  <summary><strong>Inicializar os pods</strong></summary>
 
  ### Criar a Observabilidade
  ```
  kubectl apply -f .\observability\prometheus\pvc.yaml
  kubectl apply -f .\observability\prometheus
  kubectl apply -f .\observability\grafana\pvc.yaml
  kubectl apply -f .\observability\grafana
  ```
  
  ### Criar a API Gateway
  ```
  kubectl apply -f .\api-gateway
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
