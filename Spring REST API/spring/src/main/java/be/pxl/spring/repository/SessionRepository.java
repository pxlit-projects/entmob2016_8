package be.pxl.spring.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.transaction.annotation.Transactional;

import be.pxl.spring.domain.Session;

public interface SessionRepository extends JpaRepository<Session, Integer>{

	@Transactional(readOnly = true)
	List<Session> findByUserId(int userId);
	//@Transactional(readOnly = true)
	//@Query("select s from Session s where s.")

}
