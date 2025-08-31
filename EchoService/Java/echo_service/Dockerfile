FROM maven:3.9.11-eclipse-temurin-21 AS builder

WORKDIR /app

COPY . .
RUN mvn clean package -DskipTests

FROM eclipse-temurin:21-jre AS runtime

WORKDIR /app

COPY --from=builder /app/target/echo_service-1.0-SNAPSHOT.jar ./echo-service.jar

ENV PORT=8080
EXPOSE 8080

ENTRYPOINT ["java", "-jar", "echo-service.jar"]