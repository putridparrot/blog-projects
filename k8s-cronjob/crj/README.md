# Creating a Kubernetes Cronjob in Rust

To be honest the "Rust" part of this doesn't matter, any language will do.

## Build the image

docker build -t putridparrot/crj:1.0.0 .

## Tag the image

docker tag putridparrot/crj:1.0.0 your_container_reg/putridparrot/crj:1.0.0

## Push the image

docker push your_container_reg/putridparrot/crj:1.0.0

## Checking the job

kubectl get jobs --selector=job-name=<your-cronjob-name> --sort-by=.metadata.creationTimestamp
kubectl get jobs --selector=cronjob-name=<your-cronjob-name>

## Checking the pods created

kubectl get pods --selector=job-name=<job-name>
kubectl logs <pod-name>

OR  all in one line

kubectl logs $(kubectl get pods --selector=job-name=$(kubectl get jobs --sort-by=.metadata.creationTimestamp -o jsonpath='{.items[-1].metadata.name}') -o jsonpath='{.items[0].metadata.name}')

## Checking the cronjob

kubectl get cronjobs --all-namespaces -w
```
NAMESPACE   NAME            SCHEDULE      TIMEZONE   SUSPEND   ACTIVE   LAST SCHEDULE   AGE
dev         scheduled-job   */5 * * * *   <none>     False     0        <none>          10s
dev         scheduled-job   */5 * * * *   <none>     False     1        0s              16s
```

kubectl get pods -n dev -w
```
NAME                           READY   STATUS      RESTARTS   AGE
scheduled-job-29257380-5w4rg   0/1     Completed   0          51s
```

kubectl logs -f scheduled-job-29257380-5w4rg -n dev

The log shows the output from the scheduled job as
```Current date and time: 2025-08-17 15:00:09.294317303 +00:00```

NOTE: whilst you'll see a pod after it's run the pod gets replaced by a new pod for each 
subsequent run, so you cannot view the logs of the previous pod as a new one gets created.