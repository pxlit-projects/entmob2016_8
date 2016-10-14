package be.pxl.spring.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import be.pxl.spring.domain.Session;

public interface SessionRepository extends JpaRepository<Session, Integer>{

}
