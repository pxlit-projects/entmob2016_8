package be.pxl.spring.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import be.pxl.spring.domain.Session;
import be.pxl.spring.domain.User;

public interface SessionRepository extends JpaRepository<Session, Integer>{


}
