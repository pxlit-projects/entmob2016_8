package be.pxl.spring.service;

import javax.persistence.EntityManager;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import be.pxl.spring.domain.Session;
import be.pxl.spring.domain.User;
import be.pxl.spring.repository.SessionRepository;

@Repository
@Transactional
public class SessionService {

	private EntityManager em;
	
	private SessionRepository sessionRepo;

	@Transactional
	public Session save(Session session)
	{
		return sessionRepo.save(session);
	}
}
