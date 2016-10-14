package be.pxl.spring.service;

import java.util.List;

import javax.persistence.EntityManager;
import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import be.pxl.spring.domain.Session;
import be.pxl.spring.domain.User;
import be.pxl.spring.repository.SessionRepository;

@Repository
@Transactional
public class SessionService {

	@Autowired
	private SessionRepository sessionRepo;

	@Transactional
	public Session save(Session session)
	{
		return sessionRepo.save(session);
	}
	
	@Transactional
	public Session findOne(int Id)
	{
		return sessionRepo.findOne(Id);
	}
	
	@Transactional
	public List<Session> findByUserId(int userId) {
		
		return sessionRepo.findByUserId(userId);
	}
}
